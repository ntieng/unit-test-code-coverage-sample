# unit-test-code-coverage-sample
## Check Code Coverage in console
1. Build Project
2. Install coverlet.console package
    >dotnet tool install -g coverlet.console
3. In terminal, change directory to *tests* folder
4. Run the following command to get code coverage
    >coverlet .\bin\Debug\net6.0\Coffee.Api.dll --target "dotnet" --targetargs "test --no-build"
    
    ![image](https://user-images.githubusercontent.com/87221151/197903354-9a9f71ad-e462-4aad-b42a-1a0b42a28464.png)
    
## Visualize Code Coverage in Report Generator
1. Install coverlet.collector package
    >dotnet add package coverlet.collector
2. Install report generator tool package
    >dotnet tool install -g dotnet-reportgenerator-globaltool
3. Generate xml file (*TestResults* folder will be generated)
    >dotnet vstest bin/Debug/net6.0/Coffee.Api.Tests.dll --collect:"Xplat Code Coverage"
4. Get generated Guid in TestResults folder
5. Generate Report
    >##Replace the GUID to the one that is generated in your project
    >reportgenerator -reports:".\TestResults\6e8f2cf2-4aed-4ef5-8bc2-ca0da9d0a854\coverage.cobertura.xml" -targetdir:"coverageresults" -reporttypes:Html
6. Look for *index.html* in *Coffee.Api.Tests/coverageresults folder and browse it
![image](https://user-images.githubusercontent.com/87221151/197903074-4f1ad625-48d5-448e-b5b8-9aae5bc0a841.png)
