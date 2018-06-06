<template>
    <div>
        <h1>Budget Categories</h1>

        <p>Review your budgets and Spend</p>

        <table class="table">
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Budgeted</th>
                    <th>Remaining</th>
                    <th>Avg Spent Past 3 Months</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>Groceries</td>
                    <td>$182.56</td>
                    <td>$117.44</td>
                    <td>$150.41</td>
                </tr>
                <tr>
                    <td>Mortgage</td>
                    <td>$182.56</td>
                    <td>$117.44</td>
                    <td>$150.41</td>
                </tr>
                <tr>
                    <td>Auto Fuel</td>
                    <td>$182.56</td>
                    <td>$117.44</td>
                    <td>$150.41</td>
                </tr>
                <tr>
                    <td>Spending Money</td>
                    <td>$182.56</td>
                    <td>$117.44</td>
                    <td>$150.41</td>
                </tr>
                <tr>
                    <td>Utilities</td>
                    <td>$182.56</td>
                    <td>$117.44</td>
                    <td>$150.41</td>
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