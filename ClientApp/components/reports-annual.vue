<template>
    <div>
        <h1>Annual Budget vs Expenditures</h1>

        <p>Review your annual budget and spending</p>

        <button type="button">Go to Current Month Breakdown</button>

        Table goes here.
        
    </div>
</template>

<script>
export default {
    data() {
        return {
            forecasts: null
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