#!/bin/bash

GREEN='\033[0;32m'
RED='\033[0;31m'
NC='\033[0m' # No Color

exists() {
    echo "inside exists func"
    command -v "$1" > /dev/null 2>&1
}

runEcLint(){
    echo -e "Starting up eclint linting the files of the solution! ${GREEN}[SUCCESS]${NC} Current folder:"
    pwd
    eclint check $(git ls-files -- . ':!:*.sln' . ':!:*.sln.DotSettings') > eclint.txt 2>&1
    file=eclint.txt
    if [ -s "$file" ]
    then
        echo " ECLint reported errors - build failed 😔" 1>&2
        cat $file
        echo -e "ECLint command reported a ${RED}[FAIL]${NC}. Correct the errors."
        rm eclint.txt
        exit 1
    else
        echo " No errors found. You did good 👍 "
        echo -e "ECLint command reported a ${GREEN}][SUCCESS]${NC}"
        rm eclint.txt
        exit 0
    fi
}

echo "Running eclint locally to check the solution. Checking LOCALDEV environment.."

echo "Checking that npm is installed globally.. "
if  ! [ -x "$(command -v npm)" ]; then
    echo -e "Npm is not installed globally. ${RED} [FAIL]${NC}"
    echo "Install npm globally first before running this script! See: https://nodejs.org/en/download/"
    echo "Recommended next step: Install LTS of jnodejs together with npm"
    exit 1
else
    echo -e "You have already installed npm (globally). ${GREEN} [SUCCESS]${NC}"
fi

echo "Checking that eclint is installed globally.. "
if   ! [ -x "$(command -v eclint)" ]; then
    echo -e "eclint is not installed globally. ${RED} [FAIL]${NC}"
    echo "Make sure you run this script with sufficient access : Attempting to install eclint globally next."
    echo "Trying to run this command to install eclint: npm install eclint -g"
    npm install -g eclint
    echo -e "\neclint should now be installed. Continuing! ${GREEN} [SUCCESS]${NC}"
else
    echo -e "You have already installed eclint (globally). ${GREEN} [SUCCESS]${NC}"
fi

echo "Switching up a folder to run at root folder of the source.."
pushd ..
echo -e "Switched to parent folder ${GREEN}[SUCCESS]${NC}"

runEcLint

popd #back to the eclint folder