<template>
    <div>
        <h1>Current Month Spend</h1>


        <kendo-chart ref="chart"
                 :title-text="'Total Spending by Category, June 2018'"
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
            labeltemplate: '#= category # $#= value #',
            series: [{
                type: 'pie',
                startAngle: 150,
                data: [{
                    category: 'Mortgage',
                    value: 1500,
                    color: '#76323F'
                },
                {
                    category: 'Auto Fuel',
                    value: 160.1,
                    color: '#AE3644'
                },
                {
                    category: 'Category 3',
                    value: 22.13,
                    color: '#FF6C88'
                },
                {
                    category: 'Category 4',
                    value: 220.45,
                    color: '#401B22'
                },
                {
                    category: 'Category 5',
                    value: 561.11,
                    color: '#E57F7B'
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