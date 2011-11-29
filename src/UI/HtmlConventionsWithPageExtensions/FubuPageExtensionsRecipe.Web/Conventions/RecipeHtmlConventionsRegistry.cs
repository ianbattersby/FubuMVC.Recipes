namespace FubuPageExtensionsRecipe.Web.Conventions
{
    using System;
    using System.Collections.Generic;
    using System.Web;
    using FubuMVC.Core.UI;
    using FubuPageExtensionsRecipe.Web.Models;
    using HtmlTags;

    public class RecipeHtmlConventionsRegistry : HtmlConventionRegistry
    {
        public RecipeHtmlConventionsRegistry()
        {
            this.Labels
                .If(e => e.Accessor.Name.EndsWith("_BigText"))
                .BuildBy(er => new HtmlTag("label").Text(er.Accessor.Name.Replace("_BigText", "")));

            this.Displays
                .If(e => e.Accessor.PropertyType.IsAssignableFrom(typeof(IEnumerable<String>)))
                .BuildBy(er =>
                {
                    var list = new HtmlTag("ul");
                    foreach (var item in er.Value<IEnumerable<String>>())
                    {
                        list.Append(new HtmlTag("li", t => t.Text(item)));
                    }

                    return list;
                });

            this.Displays
                .If(e => e.Accessor.PropertyType.IsAssignableFrom(typeof(ImageDisplayModel)))
                .BuildBy(er =>
                {
                    var model = er.Value<ImageDisplayModel>();
                    var urlForImage = String.Format("/Image?id={0}&width={1}&height={2}", model.Id, model.Width, model.Height);
                    return new HtmlTag("img").Attr("src", urlForImage);
                });

            this.Editors
                .If(e => e.Accessor.Name.EndsWith("_BigText"))
                .BuildBy(er => new HtmlTag("textarea"));


            this.Editors
                .If(e => e.Accessor.PropertyType.IsEnum)
                .BuildBy(er =>
                {
                    var tag = new HtmlTag("select");
                    var enumValues = Enum.GetValues(er.Accessor.PropertyType);
                    foreach (var enumValue in enumValues)
                    {
                        tag.Children.Add(new HtmlTag("option").Text(enumValue.ToString()));
                    }

                    return tag;
                });

            this.Editors
                .If(e => e.Accessor.PropertyType.IsAssignableFrom(typeof(IDictionary<String, String>)))
                .BuildBy(er =>
                {
                    var tag = new HtmlTag("div");

                    var name = er.Accessor.PropertyNames[0].Substring(0, er.Accessor.PropertyNames[0].Length - 1);
                    var dictionary = er.Value<IDictionary<String, String>>();
                    
                    var selectTag = new HtmlTag("select").Attr("name", name);
                    
                    foreach (var item in dictionary)
                    {
                        selectTag.Children.Add(new HtmlTag("option")
                                            .Text(item.Value)
                                            .Attr("value", item.Key)
                            );
                    }

                    tag.Children.Add(selectTag);

                    tag.Children.Add(
                        new HtmlTag("a")
                            .Attr("rel", String.Format("_{0}Container", name.ToLower()))
                            .Attr("href", "#")
                            .Text("add")
                            .AddClass("addItem")
                        );

                    return tag;
                });

            this.Editors
                .If(e => e.Accessor.PropertyType.IsAssignableFrom(typeof(IList<string>)))
                .BuildBy(er =>
                {
                    var tag = new HtmlTag("div").AddClass("hasHiddenGroup");

                    tag.Children.Add(
                        new HtmlTag("input")
                        .Attr("type", "text")
                        .Attr("name", er.Accessor.Name)
                        );

                    tag.Children.Add(
                        new HtmlTag("a")
                        .Attr("rel", er.ElementId)
                        .Attr("href", "#")
                        .Text("add")
                        .AddClass("addItem")
                        );

                    tag.Children.Add(new HtmlTag("ul").AddClass("dynamicList"));

                    return tag;
                });

            this.Editors
                .If(e => e.Accessor.PropertyType.IsAssignableFrom(typeof(HttpPostedFileBase)))
                .BuildBy(er => new HtmlTag("input").Attr("type", "file"));

        }
    }
}