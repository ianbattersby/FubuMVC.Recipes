COMPILE_TARGET = ENV['config'].nil? ? "Debug" : ENV['config'] # Keep this in sync w/ VS settings since Mono is case-sensitive
CLR_TOOLS_VERSION = "v4.0.30319"

buildsupportfiles = Dir["#{File.dirname(__FILE__)}/buildsupport/*.rb"]
raise "Run `git submodule update --init` to populate your buildsupport folder." unless buildsupportfiles.any?
buildsupportfiles.each { |ext| load ext }

include FileTest
require 'albacore'
load "VERSION.txt"

RESULTS_DIR = "results"
PRODUCT = "FubuMVC.Recipes"
COPYRIGHT = 'Copyright 2011 Ian Battersby, Francisco R. Aguilar, et al. All rights reserved.';
COMMON_ASSEMBLY_INFO = 'src/CommonAssemblyInfo.cs';
BUILD_DIR = File.expand_path("build")
ARTIFACTS = File.expand_path("artifacts")

@teamcity_build_id = "bt99"
tc_build_number = ENV["BUILD_NUMBER"]
build_revision = tc_build_number || Time.new.strftime('5%H%M')
BUILD_NUMBER = "#{BUILD_VERSION}.#{build_revision}"

props = { :stage => BUILD_DIR, :artifacts => ARTIFACTS }

desc "**Default**, compiles and runs tests"
task :default => [:compile_and_tests]

desc "Target used for the CI server"
task :ci => [:update_all_dependencies, :default, "template:build", :history, :publish]

desc "Update the version information for the build"
assemblyinfo :version do |asm|
  asm_version = BUILD_VERSION + ".0"
  
  begin
    commit = `git log -1 --pretty=format:%H`
  rescue
    commit = "git unavailable"
  end
  puts "##teamcity[buildNumber '#{BUILD_NUMBER}']" unless tc_build_number.nil?
  puts "Version: #{BUILD_NUMBER}" if tc_build_number.nil?
  asm.trademark = commit
  asm.product_name = PRODUCT
  asm.description = BUILD_NUMBER
  asm.version = asm_version
  asm.file_version = BUILD_NUMBER
  asm.custom_attributes :AssemblyInformationalVersion => asm_version
  asm.copyright = COPYRIGHT
  asm.output_file = COMMON_ASSEMBLY_INFO
end

desc "Prepares the working directory for a new build"
task :clean do
	#TODO: do any other tasks required to clean/prepare the working directory
	FileUtils.rm_rf props[:stage]
    # work around nasty latency issue where folder still exists for a short while after it is removed
    waitfor { !exists?(props[:stage]) }
	Dir.mkdir props[:stage]
    
	Dir.mkdir props[:artifacts] unless exists?(props[:artifacts])
end

def waitfor(&block)
  checks = 0
  until block.call || checks >10 
    sleep 0.5
    checks += 1
  end
  raise 'waitfor timeout expired' if checks > 10
end

desc "Discover recipes"
task :compile_and_tests => [:restore_if_missing, :clean, :version] do  
  FileList.new('src/*/*').exclude('src/packages/*').each do |solution_dir|
    puts "\nFound solution directory: #{solution_dir}"

    FileList.new("#{solution_dir}/*.sln").each do |solution_file|
      puts "  Compiling: #{solution_file}\n\n"
      MSBuildRunner.compile :compilemode => COMPILE_TARGET, :solutionfile => solution_file, :clrversion => CLR_TOOLS_VERSION
    end

    tests = FileList.new("#{solution_dir}/*.Tests", "#{solution_dir}/*.Tests.*").collect! { |element| 
      "#{element}/hack/".pathmap("%-1d")
    }

    runner = NUnitRunner.new :compilemode => COMPILE_TARGET, :source => solution_dir, :platform => 'x86'
    runner.executeTests tests
  end
end