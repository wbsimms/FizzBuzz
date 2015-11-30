@echo off
msbuild ElasticTransfer.xml /t:SimianReport;BuildCommon;AddEnableCoverage;TestOnly;GetCoverageReport