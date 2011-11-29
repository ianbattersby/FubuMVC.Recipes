
Basic IAuthorizationPolicy Recipe
==
FubuMVC includes a base Authorization policy that aligns itself with the ASP.NET authentication provider, it is therefore possible to implement role-based access control based on input-model using this method. Personally I avoid using any ASP.NET components whenever possible preferring to write my own, but this is a good quick-starter if you are use to this method already.

**NOTE!** Whilst writing this recipe I discovered there was no ASP.NET in-memory roles provider so I had to knock one up, obviously this is not for production use ;-)