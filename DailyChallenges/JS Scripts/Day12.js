const fs = require('fs');


//TODO: Rewrite with readline module? Right now it requires the first line to be empty
//https://attacomsian.com/blog/reading-a-file-line-by-line-in-nodejs#readline-module
function readFile(day) {
    try {
        path = `C:/Users/PC/Documents/GitHub/AdventOfCode/Input/InputDay${day}.txt`;
        // read contents of the file
        const data = fs.readFileSync(path, 'UTF-8');
    
        // split the contents by new line
        const lines = data.split(/\r?\n/);
        return lines;
    } catch (err) {
        console.error(err);
    }
}

function calculateManhattanDistance(arr) {
    return Math.abs(arr[1] - arr[3]) + Math.abs(arr[0] - arr[2]);
}

function Part1() {
    const input = readFile(12);
    const map = new Map().set('N', 0).set('E', 90).set('S', 180).set('W', 270).set('L', 'L').set('R', 'R').set('F', 'F');
    let dir = [0, 0, 0, 0]; //N, E, S, W
    let curDeg = 90; //East

    for (let i = 1; i < input.length; i++) {
        let action = {
            Direction: map.get(input[i].substr(0, 1)), 
            Value: parseInt(input[i].substr(1))
        };

        //handle action command
        if (!isNaN(action.Direction))
            dir[action.Direction / 90] += action.Value;
        else {
            switch (action.Direction) {
                case "L":
                    curDeg = ((curDeg - action.Value) + 360) % 360;
                    break;
                case "R":
                    curDeg = ((curDeg + action.Value) + 360) % 360;
                    break;
                case "F":
                    dir[curDeg / 90] += action.Value;
                    break;
            }
        }
    }

    console.log(calculateManhattanDistance(dir));
}

function Part2() {
    const input = readFile(12);
    const map = new Map().set('N', 0).set('E', 90).set('S', 180).set('W', 270).set('L', 'L').set('R', 'R').set('F', 'F');
    let waypoint = [1, 10, 0, 0]; //N, E, S, W
    let ship = [0, 0, 0, 0]; //N, E, S, W

    for (let i = 1; i < input.length; i++) {
        let action = {
            Direction: map.get(input[i].substr(0, 1)), 
            Value: parseInt(input[i].substr(1))
        };

        //handle action command
        if (!isNaN(action.Direction))
            waypoint[action.Direction / 90] += action.Value;
        else {
            switch (action.Direction) {
                case "L":
                    //shift waypoint array to the left
                    for (let j = 0; j < (action.Value / 90) % 4; j++)
                        shiftArray(waypoint, true);
                    break;
                case "R":
                    //shight waypoint array to the right
                    for (let j = 0; j < (action.Value / 90) % 4; j++)
                        shiftArray(waypoint, false);
                    break;
                case "F":
                    for (let j = 0; j < ship.length; j++)
                        ship[j] += waypoint[j] * action.Value;
                        //Ship moves Value times to the waypoint
                    break;
            }
        }

        // console.log(action);
        // console.log("Waypoint: " + waypoint);
        // console.log("Ship: " + ship);
        // console.log("-----------");
    }

    console.log(calculateManhattanDistance(ship));
}

function shiftArray(array, toLeft) {
    if (toLeft) {
        let firstElem = array.shift();
        array.push(firstElem);
    } else {
        let lastElem = array.pop();
        array.unshift(lastElem);
    }

    return array;
}

Part2();