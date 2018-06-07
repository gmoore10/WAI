<template>
    <div>
        <h1>Transactions</h1>

        <p>Go over and add transactions</p>

        <button type="button">Add Transaction</button>

        <table class="table">
            <thead>
                <tr>
                    <th>Description</th>
                    <th>Date</th>
                    <th>Amount</th>
                    <th>Budget Remaining</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>Publix Trip</td>
                    <td>4/6/2018</td>
                    <td>$182.56</td>
                    <td>$117.44</td>
                </tr>
                <tr>
                    <td>Weekend Party</td>
                    <td>4/9/2018</td>
                    <td>$441.22/td>
                    <td>$(323.78)</td>
                </tr>
                <tr>
                    <td>Weekend Party</td>
                    <td>4/9/2018</td>
                    <td>$441.22/td>
                    <td>$(323.78)</td>
                </tr>
                <tr>
                    <td>Weekend Party</td>
                    <td>4/9/2018</td>
                    <td>$441.22/td>
                    <td>$(323.78)</td>
                </tr>
                <tr>
                    <td>Weekend Party</td>
                    <td>4/9/2018</td>
                    <td>$441.22/td>
                    <td>$(323.78)</td>
                </tr>
            </tbody>
        </table>
        
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