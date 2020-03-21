![Xeroxcore logo](https://github.com/Xeroxcore/Xeroxcore/blob/master/resources/images/Xeroxcore_Logo.png)
<br/><br/>
![GitHub repo size](https://img.shields.io/github/repo-size/xeroxcore/xheader-security)
![GitHub issues](https://img.shields.io/github/issues/xeroxcore/xheader-security)
[![License: GPL v3](https://img.shields.io/badge/License-GPLv3-blue.svg)](https://github.com/Xeroxcore/xheader-security/blob/master/LICENSE)

## Introduction

<!--ts-->

## Table of Contents

- [Getting started](#getting-started)
- [Prerequisites](#prerequisites)
- [Installing](#installing)
  - [Dotnet core 3](#dotnet-core-3)
    - [Linux-CentOS](#linux-centos-1)
    - [Windows 10](#windows-10-1)
- [Deployment](#deployment)
- [Built With](#built-with)
- [Contributing](#contributing)
- [Versioning](#versioning)
- [Authors](#authors)
- [License](#license)

<!--te-->

### Getting started

These instructions are aimed at helping you set up the project for development or testing purposes.
If you wish to put the project in production, please check our [Deployment section](#deployment).

### Prerequisites

The following tools are required for the API to function please make sure that necessary tools
are installed and if not, install them utilizing the provider's main pages.

- [.Net Core](https://dotnet.microsoft.com/download/dotnet-core/3.0) - dotnet core 3 and greater

### Installing

This section will help you to set up your development environment. For production deployment please
check the [Deployment section](#deployment). Since the app was developed in CentOS 7, most of the
commands might be centos related.

#### Dotnet core 3

This installation process was made for centos 7 & Windows 10 and might not work on your system. if you are
utilizing an alternative OS or distribution then please check the [.Net Core](https://dotnet.microsoft.com/download/linux-package-manager/rhel/sdk-current) website for more info. Ps, you might need to enable
third-party repositories.

##### Linux-CentOS

```
begin by opening a new shell window and follow the steps below:
1. sudo rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm
2. sudo yum install dotnet-sdk-3.0.x86_64 -y
3. enter the following command after the installation is complete to verify the installation
  dotnet --version
```

###### Windows 10

```
1. Go to the following URL and download the [.Net Core SDK](https://dotnet.microsoft.com/download).
2. Open the install dotnet-sdk-3.x.x-win-x64.exe.
3. follow the installation instructions.
4. Open CMD(Command prompt) and paste dotnet --Version to verify the installation.
```

### Deployment

#### Nuget.Config

#### Push To Github

#### Install package in your app

### Built With

Middleware was built with the following tools in a Linux Environment (CentOS 7).

- [Visual Studio Code](https://code.visualstudio.com/) - Code Editor
- [.Net Core](https://dotnet.microsoft.com/) - Dotnet Core Runtime

### Contributing

### Versioning

We use [SemVer](http://semver.org/) for versioning. Please visit their website for more
information to understand how different versions might affect you and your project.

### Authors

- **Nasar Eddaoui** - _Initial work_ - [Nasar Eddaoui](https://github.com/Nasar165)

See also the list of [contributors](https://github.com/Xeroxcore/Xeroxcore//graphs/contributors) who participated in this project.

### License

This project is licensed under the GNU General Public License v3.0 - see the [LICENSE](LICENSE) file for details
