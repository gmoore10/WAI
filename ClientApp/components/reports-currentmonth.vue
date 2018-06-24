<template>
    <div>
        <h1>Current Month Spend</h1>
        <kendo-datasource ref="datasource"
            :transport-read-data-type="'json'"
            :transport-read-url="'/api/reports'">
            </kendo-datasource>
        <kendo-chart ref="chart"
                 :title-text="'Total Spending by Category, June 2018'"
                 :title-position="'bottom'"
                 :chart-area-background="''"
                 :legend-visible="false"
                 :data-source-ref="'datasource'"
                 :series-defaults-labels-visible="true"
                 :series="series"
                 :series-defaults-labels-background="'transparent'"
                 :series-defaults-labels-template="this.chartOptions.labeltemplate"
                 :series-colors="this.chartOptions.seriesColors"
                 :tooltip-visible="true">
    </kendo-chart>
        
    </div>
</template>

<script>
export default {
    data() {
        return {
            series: [{ field: "value", type: 'pie'}]
        }
    },
    computed: {
        chartOptions() {
            return this.$store.getters.chartOptions
        }
    },

    methods: {
        
    },

    async created() {
    }
}
</script>

<style>
</style>