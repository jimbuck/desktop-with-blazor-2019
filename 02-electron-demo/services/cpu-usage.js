const os = require('os');

//Grab first CPU Measure
let prevMeasure = _getCurrentCpu();

module.exports = function getCpuUsage() {
	const currentMeasure = _getCurrentCpu();
	const percent = 100 - ~~(100 * (currentMeasure.idle - prevMeasure.idle) / (currentMeasure.total - prevMeasure.total));
	prevMeasure = currentMeasure;
	return percent;
}

function _getCurrentCpu() {

	let totalIdle = 0, totalTick = 0;
	const cpus = os.cpus();

	//Loop through CPU cores
	for (let cpu of cpus) {

		//Total up the time in the cores tick
		for (type in cpu.times) {
			totalTick += cpu.times[type];
		}

		//Total up the idle time of the core
		totalIdle += cpu.times.idle;
	}

	//Return the average Idle and Tick times
	return { idle: totalIdle / cpus.length, total: totalTick / cpus.length };
}