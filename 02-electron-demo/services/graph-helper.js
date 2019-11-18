const { SmoothieChart, TimeSeries } = require('smoothie');

const lineWidth = 2;
const SERIES_OPTIONS = [
  { strokeStyle: 'rgba(65,105,225)', lineWidth },
  { strokeStyle: 'rgba(0,0,205, 1)', lineWidth },
  { strokeStyle: 'rgba(70,130,180, 1)', lineWidth },
	{ strokeStyle: 'rgba(100,149,237, 1)', lineWidth },
	{ strokeStyle: 'rgba(30,144,255, 1)', lineWidth },
	{ strokeStyle: 'rgba(0,0,255, 1)', lineWidth },
	{ strokeStyle: 'rgba(0,206,209)', lineWidth },
	{ strokeStyle: 'rgba(106,90,205, 1)', lineWidth }
];

/**
 * 
 * @param {HTMLElement} el 
 * @param {CpuInfo[]} cpus 
 */
function renderCpuGraphs(el, renderDelay, cpus) {

	const canvas = document.createElement('canvas');
	canvas.id = `cpu-graph`;
	canvas.style = 'width: 100%; height: 200px;';
	el.append(canvas);

	const dataSet = cpus.map(() => new TimeSeries());
	const graph = new SmoothieChart({
		responsive: true,
		millisPerPixel: 20,
		grid: { strokeStyle: '#555555', lineWidth: 1, millisPerLine: 1000, verticalSections: 4 },
		minValue:0, maxValue:100
	});

	dataSet.forEach((ts, i) => graph.addTimeSeries(ts, SERIES_OPTIONS[i]));
	graph.streamTo(canvas, renderDelay);

	return {
		/**
		 * 
		 * @param {CpuInfo[]} cpus 
		 */
		update(cpuStats) {
			const now = Date.now();
			cpuStats.forEach((stat, i) => {
				dataSet[i].append(now, stat);
			});
		}
	}
}

module.exports = {
	renderCpuGraphs
};