#!groovy
pipeline {
    agent any

    stages {
        stage('Checking out code..') {
            steps {
                echo 'Pulling code..'
                git credentialsId: 'd3312dd9-7d5c-4b80-8a01-590fe80e10e7', url: 'https://github.com/ryandorn/ChickenDinnerFL.git'
            }
        }
        stage('Cleaning code and restoring nuget packages'){
            steps {
                echo '!Add ms build or nuget steps for package management.'
                }
        }
        stage('Building solution..') {
            steps {
                echo '!Add ms build steps.'
            }
        }
        stage('Test') {
            steps {
                echo 'Testing..'
            }
        }
        stage('Deploy') {
            steps {
                echo 'Deploying....'
            }
        }
    }
}
