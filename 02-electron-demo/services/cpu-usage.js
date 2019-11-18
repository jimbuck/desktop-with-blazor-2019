const os = require('os');
const { StatTracker } = require('./stat-tracker');

class CpuTracker {
	constructor(cpu) {
		this.prevTotal = new StatTracker(this._getTotal(cpu));
		this.prevIdle = new StatTracker(cpu.times.idle);
	}

	update(cpu) {
		const { diff: total } = this.prevTotal.update(this._getTotal(cpu));
		const { diff: idle } = this.prevIdle.update(cpu.times.idle);
		const active = total - idle;
		const idlePercent = ~~(100 * idle / total);
		const activePercent = 100 - idlePercent;

		return { activePercent, idlePercent, active, idle, total };
	}

	_getTotal(cpu) {
		return Object.keys(cpu.times).reduce((total, time) => total += cpu.times[time], 0);
	}
}

class CpuUsageTracker {

	constructor(cpus) {
		this.cpuTrackers = cpus.map(cpu => new CpuTracker(cpu));
	}

	update(cpus) {
		const cpuStats = cpus.map((cpu, i) => this.cpuTrackers[i].update(cpu));
		const totals = cpuStats.reduce((total, stats) => {
			total.idle += stats.idle;
			total.ticks += stats.total;
			return total;
		}, {idle: 0, ticks: 0});
		const totalPercent = 100 - ~~(100 * totals.idle / totals.ticks);
		return {
			total: totalPercent,
			cpus: cpuStats.map(stats => stats.activePercent)
		};
	}

	renderStats(el, cpus, total) {
		el.innerHTML = `<strong>CPUs:</strong> ${cpus.length}<br />
<strong>Model:</strong> ${cpus[0].model}<br />
<strong>Usage:</strong> ${total}%<br />
<strong>Memory:</strong> ${_humanFileSize(os.freemem())}/${_humanFileSize(os.totalmem())}<br />`;
	}
}

module.exports = {
	CpuUsageTracker
};

function _humanFileSize(size) {
	const i = Math.floor(Math.log(size) / Math.log(1024));
	return (size / Math.pow(1024, i)).toFixed(2) * 1 + ' ' + ['B', 'kB', 'MB', 'GB', 'TB'][i];
}