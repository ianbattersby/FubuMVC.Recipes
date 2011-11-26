
IRedirectable Recipe
==
Using IRedirectable on a ViewModel implements a FubuContinuation as a *property* on the model. Setting this property during your handler/controller causes the behavior chain to automatically jump to the desired new chain. The advantage here is that it allows you to keep your return type as your model opposed to a [standard FubuContinuation](https://github.com/ianbattersby/FubuMVC.Recipes/tree/master/src/Continuations/FubuMVCContinuation).