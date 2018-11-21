pipeline {
  agent any
  triggers {
        'H 5 * * *'
    }
  stages {
    stage('Checkout') {
      steps {
        git(url: 'https://github.com/NicolasGhersiVDQ/TestsInfoCollecte.git', branch: 'master')
      }
    }
    stage('Build') {
      steps {
        bat "\"${tool 'MSBuild'}\" InfoCollecte.sln /t:Restore /p:Configuration=Debug /p:Platform=\"Any CPU\""
      }
    }
    stage('Tests') {
      steps {
        bat "\"${tool 'NUnit'}\" .\\InfoCollecte\\bin\\Debug\\InfoCollecte.dll"
      }
    }
    stage('Report') {
      steps {
        nunit(testResultsPattern: 'TestResult.xml', failIfNoResults: true, keepJUnitReports: true)
      }
    }
    stage('Monitor') {
      steps {
        bat '.\\InfoCollecte\\bin\\Debug\\TestResultReader.exe'
      }
    }
  }
}