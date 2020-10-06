
function extraLongFactorials(n) {
    //var fact = 1; var fact2;
    var fact = BigInt(1);
    var nn = BigInt(n);
    while (nn > 0) {
        fact = fact * nn;
        //fact =  BigInt(fact);        
        nn--;
    }
    var big = BigInt(fact);
    //var big2=BigInt(big)
    console.log(big.toString());

}

function timeConversion(s) {
    /*
     * Write your code here.
     */
    var sarray = s.split(':');
    var hr = parseInt(sarray[0]);
    var min = sarray[1];
    var sec = sarray[2].substring(0,2);
    var ampm = sarray[2].substring(2, 2);

    var mhr = 0;
    if (ampm == "AM") {
        if (hr == 12)
            mhr = 0;
        else 
        mhr = hr;
    } else {
        if (hr == 12)
            mhr = 12;
        else
        mhr = hr + 12;
    }

    var mhrstring = mhr;
    if (mhr < 10)
        mhrstring = "0" + mhr;

    return mhrstring + ":" + min + ":" + sec;
}
function birthdayCakeCandles(ar) {
    var highervalue = ar[0];
    var numberofHigherValues = 1;
    for (var i = 1; i < ar.length; i++) {
        if (ar[i] > highervalue) {
            highervalue = ar[i];
            numberofHigherValues = 1;
        }
        else if (highervalue == ar[i]) {
            numberofHigherValues++;
        } 
    }
    return numberofHigherValues;
}

//1 2 3 4 5
function miniMaxSum(arr) {
    var minNum = arr[0];
    var maxNum = arr[0];

    var totalSum = arr[0];

    for (var i = 1; i < arr.length; i++) {

        if (arr[i] < minNum)
             minNum = arr[i];

        if (arr[i] > maxNum)
            maxNum = arr[i];

        totalSum += arr[i];
    }

    var totalMinSum = totalSum - maxNum;
    var totalMaxSum = totalSum - minNum;

    console.log(totalMinSum + " " + totalMaxSum);
}


function staircase(n) {

    for (var i = 0; i < n; i++) {
        var spaces = "";
        var numberOfSpaces = n - 1 - i;
        while (numberOfSpaces > 0) {
            spaces += " ";
            numberOfSpaces--;
        }
        var numberofHashes = i + 1;
        var hashes = "";
        while (numberofHashes > 0) {
            hashes += "#";
            numberofHashes--;
        }
        console.log(spaces +hashes);
    }
}

function plusMinus(arr) {
    var len = arr.length;
    var ptotal = 0;
    var ntotal = 0;
    var ztotal = 0;
    for (var i = 0; i < len; i++) {
        if (arr[i] > 0)
            ptotal++;
        else if (arr[i] < 0)
            ntotal--;
        else ztotal++;
    }

    var pdec = ptotal / len;
    var ndec = ntotal / len;
    var zdec = ztotal / len;

    var pdecr = Math.round(pdec * 1000000) / 1000000;
    var ndecr = Math.round(ndec * 1000000) / 1000000;
    var zdecr = Math.round(zdec * 1000000) / 1000000;
    console.log(Math.abs(pdecr));
    console.log(Math.abs(ndecr));
    console.log(Math.abs(zdecr));
    //return [abs(pdecr), abs(ndecr), abs(zdecr)];
}
/*
11 2 4
4 5 6
10 8 -12
*/
function diagonalDifference(arr) {
    // Write your code here
    var hor = 0;
    var ver = 0;

    var len = arr[0].length;
    for (var i = 0; i < len; i++) {
        hor += arr[i][i];
        
        ver += arr[i][len - i];
    }
    
    if (hor < ver)
        return hor - ver;
    else return ver - hor;
}



function compareTriplets(a, b) {
    var alicePoints = 0;
    var bobPoints = 0;
    for (var i = 0; i < a.length; i++) {
        if(a[i]==b[i])
            continue;
        else
        {
            if (a[i] > b[i])
                alicePoints++;
            else bobPoints++;
        }
    }
    return [alicePoints, bobPoints];
}

function simpleArraySum(ar) {
    /*
     * Write your code here.
     */
    var sum = 0;
    for (var i = 0; i < ar.length; i++) {
        sum += ar[i];
    }
    return sum;
}

//UDDDUDUU
function countingValleys(n, s) {
    var steps = 0;
    var numberOfValleys = 0;
    var enteredValley = false;
    for (var i = 0; i < n; i++) {
        
        if (s[i] == 'U')
            steps++;
        else steps--;

        if (steps < 0) {
            enteredValley = true;
        }
        if (steps == 0 && enteredValley) {
            numberOfValleys++;
            enteredValley = false;
        }

    }

    return numberOfValleys;
}

//10 20 20 10 10 30 50 10 20
function sockMerchant(n, ar) {
    var numberofPairs = 0;
    for (var i = 0; i < n - 1; i++) {
        var alreadyCounted = false;
        for (var k = 0; k < i; k++) {
            if (ar[i] == ar[k]) {
                alreadyCounted = true;
                break;
            }
        }
        if (alreadyCounted) {
            continue;
        }
        var numberOfSocs = 1;
        for (var j = i+1; j < n; j++) {
            if (ar[i] == ar[j])
                numberOfSocs++;
        }
        if (numberOfSocs > 1) {
            var numOfColorPairReminder = numberOfSocs % 2;
            var pairedNumeberOfSocks = numberOfSocs - numOfColorPairReminder;
            numberofPairs += pairedNumeberOfSocks / 2;
        }
    }

    return numberofPairs;
}



function gradingStudents(grades) {
    // Write your code here
    var results = new Array(grades.length);
    for (var i = 0; i < grades.length; i++) {
        if (grades[i] < 38)
            results[i] = grades[i];
        else {
            //Do rounding
            var grade = grades[i];
            var reminder = grade % 5;
            var thenextMultipleofFive = grade + (5-reminder);
            var reminderOfFive = thenextMultipleofFive - grade;
            if (reminderOfFive < 3) {
                //Do Rounding
                results[i] = thenextMultipleofFive;
            } else {
                results[i] = grades[i];
            }
        }
    }
    return results;
}


































//function numOffices(grid) {
//    var result = 0;
//    //Put your code here.
//    //var numbofoffices=0;
//    var maxNumberOfOnes = 0;
//    for(var i=0;i<grid.length;i++){
//        var curArray = grid[i];
//        var arrayLength = curArray.length;
//        var j = 0;
//        var office = [];
//        var alreadyOffice = false;
       
//        while (j < curArray.length) {
//            var currentNumberOfOnes = 0;
//            for (var l = 0; l < office.length; l++) {
//                if (office[l] == j + (i * arrayLength)) {
//                    alreadyOffice = true;
//                    break;
//                }
//            }
//            if (alreadyOffice)
//                continue;

//            if (curArray[j] == 0) {
//                j++;
//                continue;
//            }
//            else {
//                office.push(j+(i*arrayLength));
//                currentNumberOfOnes++;
               
//                var k = j + 1;
//                while (k < curArray.length) {
//                    if (curArray[k] == 0) {
//                        //j = k - 1;//End Of Horizontal
//                        break;
//                    } else {
//                        office.push(k+(i*arrayLength));
//                        currentNumberOfOnes++;
//                        var q = k;
//                        while (grid[i + 1][q] != 0) {
//                            office.push(q + (i * arrayLength));
//                            currentNumberOfOnes++;
//                            q++;
//                        }
                        
//                    }
//                }
//                var qq = 0;
//                while (grid[i + 1][qq] != 0) {
//                    office.push(qq + (i * arrayLength));
//                    currentNumberOfOnes++;
//                    qq++;
//                }
//                numOffices++;
//            }
//            if (currentNumberOfOnes > maxNumberOfOnes)
//                maxNumberOfOnes = currentNumberOfOnes;
//        }

//    }
    
//    return maxNumberOfOnes;
//};

//function minimumConcat(initial, goal) {
//    //Put your code here.
//    //
//    //abc
//    //acdbc
//    //abc
//    //abcbc

//    var i = 0;
//    var j = 0;
//    var numOfmin = 0;
//    var found = false;
//    while (i < goal.length) {
//        found = false;
//        while (j<initial.length) {
//            if (goal[i] == initial[j]) {
//                j++;
//                i++;
//                found = true;
//                break;
//            } else {
//                j++;
//                //
//                //j = 0;
//            }
            
//        }
//        if (found && ) {
//            //numOfmin++;
//        }

//        if (!found) {
//            numOfmin = -1;
//            break;
//        }
        
//    }

//        //for (var j = 0; j < initial.length; j++) {
//        //    for (var i = 0; i < goal.length; i++) {
//        //        if (initial[j] == goal[i]) {
                    
//        //        }
//        //    }
//        //}
    
//    return 0;
//}