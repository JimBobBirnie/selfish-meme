<template>
  <div>
    This is my vue. Hello
    <div ref="plot"></div>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';

export default Vue.extend({
  data() {
    return {
      traces: [
        { x: [1], y: [1], stackgroup: 'one', groupnorm: 'percent' },
        { x: [1], y: [1], stackgroup: 'one' }
      ]
    };
  },
  mounted() {
    const plotElement: HTMLElement = this.$refs.plot;

    Plotly.newPlot(plotElement, this.traces, {
      title: 'Normalized stacked and filled line chart',
      xaxis: {
        range: [0, 100]
      }
    });
  }
});
</script>
