<template>
    <div>
        <h1>Current Month Spend</h1>

        <p>Review your monthly spend</p>

        <button type="button">Go to Annual Breakdown</button>

        Chart goes here.
        
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