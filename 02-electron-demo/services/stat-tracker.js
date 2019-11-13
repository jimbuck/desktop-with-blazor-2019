
class StatTracker {
	constructor(initial) {
		this.prev = initial;
	}

	update(current) {
		const prev = this.prev;
		const diff = current - prev;
		this.prev = current;
		return { diff, current, prev };
	}
}

module.exports = {
	StatTracker
};
