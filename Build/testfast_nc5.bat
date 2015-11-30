@echo off
msbuild FizzBuzz.xml /t:SimianReport;BuildCommon;AddEnableCoverage;TestOnly
REM ;GetCoverageReport