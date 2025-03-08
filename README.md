![Hackathon Logo](docs/images/hackathon.png?raw=true "Hackathon Logo")

<!-- # Sitecore Hackathon 2025

- MUST READ: **[Submission requirements](SUBMISSION_REQUIREMENTS.md)**
- [Entry form template](ENTRYFORM.md)

### ⟹ [Insert your documentation here](ENTRYFORM.md) << -->

# Sitecore AI-Generated Templates

## Team Name

**⟹ The Highlanders**

## Category

**⟹ Free with IA**

## Description

This project introduces AI-powered automation within Sitecore's CMS to accelerate the creation of data structures. Unlike traditional Sitecore AI implementations that focus on content generation, this module generates YML files for templates, serializing them in real time based on user instructions. It adheres to the Helix architecture convention, ensuring a structured, scalable, and maintainable Sitecore implementation.

### Module Purpose

**Problem Solved**

Creating Sitecore templates manually is time-consuming and prone to human error. Developers must adhere to Helix conventions, manage multiple YML files, and maintain consistency across templates, sections, and fields.

### Solution

This module allows users to generate Sitecore templates dynamically by providing instructions to AI. The AI interprets the input, structures the templates according to Helix guidelines, and produces the required YML files. The generated files include:

- **Template YMLs** structured into folders and fields

- **GUIDs** assigned dynamically for templates, sections, and fields

- **Serialized output in real-time** for immediate integration

The solution is integrated within Sitecore's ribbon as an option called **Template Generator**. This feature includes a button named **Generate with IA**, which displays a modal where users can input a description of the desired template structure. Based on this input, the AI processes the request, generating the required YML files according to the Helix conventions and the specified prompt.

## Video Link

[Provide a link to your demo video]

## Pre-requisites and Dependencies

This module requires:

> **Sitecore 10.4**

> **Sitecore CLI** installed and configured

> **A valid OpenAI API key** (for AI-based generation, must be your personal API key)

## Installation Instructions

### The Prefix that will be used on SOLR, Website and Database instances.

- $Prefix = "highlanders"

### The Password for the Sitecore Admin User. This will be regenerated if left on the default.

- $SitecoreAdminPassword = "b"

### The root folder with the license file and WDP files.

- $SCInstallRoot = "C:\resources104"

### Root folder to install the site to. If left on the default **[systemdrive]:\\inetpub\\wwwroot** will be used

- $SitePhysicalRoot = "C:\cf\Hackathon2025"

### The name for the XConnect service.

- $XConnectSiteName = "$prefix.xconnect"

### The Sitecore site instance name.

- $SitecoreSiteName = "$prefix.local"

### Identity Server site name

- $IdentityServerSiteName = "$prefix.identityserver"

### The Path to the license file

- $LicenseFile = "$SCInstallRoot\license.xml"

### The URL of the Solr Server

- $SolrUrl = "https://localhost:8984/solr"

### The Folder that Solr has been installed to.

- $SolrRoot = "C:\Solr-8.11.2"

### The Name of the Solr Service.

- $SolrService = "Solr-8.11.2"

### The DNS name or IP of the SQL Instance.

- $SqlServer = "localhost"

### A SQL user with sysadmin privileges.

- $SqlAdminUser = "sa"

### The password for $SQLAdminUser.

- $SqlAdminPassword = "123"

### The path to the XConnect Package to Deploy.

- $XConnectPackage = (Get-ChildItem "$SCInstallRoot\Sitecore _ rev. _ (OnPrem)\_xp0xconnect.\*scwdp.zip").FullName

### The path to the Sitecore Package to Deploy.

- $SitecorePackage = (Get-ChildItem "$SCInstallRoot\Sitecore _ rev. _ (OnPrem)\_single.\*scwdp.zip").FullName

### The path to the Identity Server Package to Deploy.

- $IdentityServerPackage = (Get-ChildItem "$SCInstallRoot\Sitecore.IdentityServer _ rev. _ (OnPrem)\_identityserver.\*scwdp.zip").FullName

### The Identity Server password recovery URL, this should be the URL of the CM Instance

- $PasswordRecoveryUrl = "https://$SitecoreSiteName"

### The URL of the Identity Server

- $SitecoreIdentityAuthority = "https://$IdentityServerSiteName"

### The URL of the XconnectService

- $XConnectCollectionService = "https://$XConnectSiteName"

### The random string key used for establishing connection with IdentityService. This will be regenerated if left on the default.

- $ClientSecret = "qaz123456!"

### Pipe-separated list of instances (URIs) that are allowed to login via Sitecore Identity.

- $AllowedCorsOrigins = "https://$SitecoreSiteName"

### The parameter for the installing delta WDP packages

- $Update = $false

### The elastic pool name for deploy databases from the SQL Azure.

- $DeployToElasticPoolName = ""

## Run the installation process

1.  make sure your domain is like this one: https://highlanders.local/

2.  clone the main branch in a folder

3.  open the solution

4.  build the solution and restore the nuget packages

5.  using the Website project, deploy the project to the sitecore instance using the publishin process

6.  Open a PS Terminal in the root of the solution

7.  Execute the following commands -- dotnet tool restore

    ```plaintext

    dotnet sitecore init

    dotnet sitecore plugin init

    dotnet sitecore login --authority https://highlanders.identityserver/ --cm https://highlanders.local/ --allow-write true

    ```

8.  Do the login process and close the window

    ```plaintext

    dotnet sitecore ser push

    ```

10. Publish all website

## Usage Instructions

1. Navigate to **Template Generator** in the Sitecore ribbon.

2. Click on **Generate with IA** to open the modal.

   ![Ribbon Btn](docs/images/Ribbon_btn.png?raw=true "Ribbon Btn")

3. Enter a structured description of the template to be created, for example:

   ```plaintext

   Create a Sitecore template named 'Product' with sections 'General' and 'Specifications'. Include fields 'Name', 'Price', and 'Description' with appropriate Sitecore field types.

   ```

   ![Prompt msg](docs/images/Prompt_msg.png?raw=true "Prompt msg")


4. The AI will generate the corresponding YML files following Helix conventions.

5. Review and serialize the generated YML files in real-time.

6. Import the serialized templates into Sitecore.

7. Use the newly created templates to build content structures efficiently.


   ![Output template](docs/images/Output_template.png?raw=true "Output_template")


## Example Output

Generated YML files will follow this structure:

```yml
ID: 0c7b310c-f3ac-4698-ae51-5ee7f9207b78
Parent: bed62742-5fd3-4a7d-bf46-673f86176ac4
Template: 1ca8c322-9f7c-4692-a4d7-91aaa82d775a
Path: /sitecore/templates/Feature/CreateArticle/Content/Author
```

![Output1](docs/images/Output-structure.jpeg?raw=true "Output1")

![Output2](docs/images/Output_structure2.png?raw=true "Output2")

## 🛠 Contributions

Contributions are welcome! If you find a bug or have an improvement idea, feel free to open an issue or submit a pull request. 🚀

## Comments

If you'd like to make additional comments that is important for your module entry.
