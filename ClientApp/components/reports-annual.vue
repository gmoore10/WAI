<template>
    <div>
        <h1>Annual Budget vs Expenditures</h1>

        <table>
            <thead>
                <tr>
                    <th>Category</th>
                    <th>Jan</th>
                    <th>Feb</th>
                    <th>Mar</th>
                    <th>Apr</th>
                    <th>May</th>
                    <th>Jun</th>
                    <th>Jul</th>
                    <th>Aug</th>
                    <th>Sep</th>
                    <th>Oct</th>
                    <th>Nov</th>
                    <th>Dec</th>
                    <th>Total</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>Mortgage</td>
                    <td>$950.00</td>
                    <td>$950.00</td>
                    <td>$950.00</td>
                    <td>$950.00</td>
                    <td>$950.00</td>
                    <td>$950.00</td>
                    <td>$950.00</td>
                    <td>$950.00</td>
                    <td>$950.00</td>
                    <td>$950.00</td>
                    <td>$950.00</td>
                    <td>$950.00</td>
                    <td>$11,400.00</td>
                </tr>
                <tr>
                    <td>Auto Fuel</td>
                    <td>$100.00</td>
                    <td>$100.00</td>
                    <td>$100.00</td>
                    <td>$100.00</td>
                    <td>$100.00</td>
                    <td>$100.00</td>
                    <td>$100.00</td>
                    <td>$100.00</td>
                    <td>$100.00</td>
                    <td>$100.00</td>
                    <td>$100.00</td>
                    <td>$100.00</td>
                    <td>$1,200.00</td>
                </tr>
            </tbody>
            <tfoot>
                <tr>
                    <th>Total: </th>
                    <th>$1,050.00</th>
                    <th>$1,050.00</th>
                    <th>$1,050.00</th>
                    <th>$1,050.00</th>
                    <th>$1,050.00</th>
                    <th>$1,050.00</th>
                    <th>$1,050.00</th>
                    <th>$1,050.00</th>
                    <th>$1,050.00</th>
                    <th>$1,050.00</th>
                    <th>$1,050.00</th>
                    <th>$1,050.00</th>
                    <th>$12,600.00</th>
                </tr>
            </tfoot>
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
table {
    border: 1px solid #cccccc;
    width: 100%;
}
table > thead > tr > th, 
table > tfoot > tr > th,
table > tbody > tr > td:last-child {
    background-color: #76323F;
    color: #E8E8E8;
    padding: 2px;
    font-weight: bold;
}

table > thead > tr > th:last-child, 
table > tfoot > tr > th:last-child,
table > tbody > tr > td:last-child {
    min-width: 100px;
    text-align: right;
}

table > tbody > tr > td {
    padding: 1px;
}

table > thead > tr > th {
    text-align: center;
}

table > tbody > tr > td {
    text-align: right;
}

table > thead > tr > th:first-child {
    text-align: left;
}

table > tbody > tr > td:first-child {
    text-align: left;
}

table> tbody > tr:nth-child(even) {
    background-color: rgb(0, 0, 0, 0.05)
}

table > thead > tr > th:first-child {
    min-width: 150px;
}
</style>