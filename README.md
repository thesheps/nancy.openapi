# nancy.openapi
OpenApi/swagger documentation generation for NancyFX.  Integration with this repository is designed to be as trivial as possible:

- Pull down the NuGet package.
- Create an implementation of the IApiDescription interface to describe your Api at the top-level (Ie author, license information).
- Create a derivative of MetadataModule for every module you wish to serve Api documentation from.

2 new routes will be added at the root of your application:

- /swagger.json

This is the combined documentation which is automatically generated using each of the metadata modules.

- /api-docs

This is a bundled implementation of the <a href="http://swagger.io/swagger-ui/">Swagger Ui</a> project.  It consumes the specification created at the swagger.json route.
