<template>
    <div>
        <h1>Current Month Spend</h1>

        <p>Review your monthly spend</p>

        

        <kendo-chart ref="chart"
                 :title-text="'Share of Internet Population Growth, 2007 - 2012'"
                 :title-position="'bottom'"
                 :chart-area-background="''"
                 :legend-visible="false"
                 :series-defaults-labels-visible="true"
                 :series-defaults-labels-background="'transparent'"
                 :series-defaults-labels-template="labeltemplate"
                 :series="series"
                 :tooltip-visible="true">
    </kendo-chart>
        
    </div>
</template>

<script>
export default {
    data() {
        return {
            labeltemplate: '#= category # #= value #%',
            series: [{
                type: 'pie',
                startAngle: 150,
                data: [{
                    category: 'Asia',
                    value: 53.8,
                    color: '#9de219'
                },
                {
                    category: 'Europe',
                    value: 16.1,
                    color: '#90cc38'
                },
                {
                    category: 'Latin America',
                    value: 11.3,
                    color: '#068c35'
                },
                {
                    category: 'Africa',
                    value: 9.6,
                    color: '#006634'
                },
                {
                    category: 'Middle East',
                    value: 5.2,
                    color: '#004d38'
                },
                {
                    category: 'North America',
                    value: 3.6,
                    color: '#033939'
                }]
            }]
        }
    },

    methods: {
    },

    async created() {
        // ES2017 async/await syntax via babel-plugin-transform-async-to-generator
        // TypeScript can also transpile async/await down to ES5
        
    }
}
</script>

<style>
</style>