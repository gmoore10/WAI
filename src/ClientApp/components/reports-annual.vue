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
                <tr v-for="category in this.$store.getters.categories" v-bind:key="category.id">
                    <td>{{ category.name }}</td>
                    <td>{{ transactions("January", 2018, category.id) }}</td>
                    <td>{{ transactions("February", 2018, category.id) }}</td>
                    <td>{{ transactions("March", 2018, category.id) }}</td>
                    <td>{{ transactions("April", 2018, category.id) }}</td>
                    <td>{{ transactions("May", 2018, category.id) }}</td>
                    <td>{{ transactions("June", 2018, category.id) }}</td>
                    <td>{{ transactions("July", 2018, category.id) }}</td>
                    <td>{{ transactions("August", 2018, category.id) }}</td>
                    <td>{{ transactions("September", 2018, category.id) }}</td>
                    <td>{{ transactions("October", 2018, category.id) }}</td>
                    <td>{{ transactions("November", 2018, category.id) }}</td>
                    <td>{{ transactions("December", 2018, category.id) }}</td>
                    <td>{{ transactions(null, 2018, category.id) }}</td>
                </tr>
            </tbody>
            <tfoot>
                <tr>
                    <th>Total: </th>
                    <th>{{ transactions("January", 2018, null) }}</th>
                    <th>{{ transactions("February", 2018, null) }}</th>
                    <th>{{ transactions("March", 2018, null) }}</th>
                    <th>{{ transactions("April", 2018, null) }}</th>
                    <th>{{ transactions("May", 2018, null) }}</th>
                    <th>{{ transactions("June", 2018, null) }}</th>
                    <th>{{ transactions("July", 2018, null) }}</th>
                    <th>{{ transactions("August", 2018, null) }}</th>
                    <th>{{ transactions("September", 2018, null) }}</th>
                    <th>{{ transactions("October", 2018, null) }}</th>
                    <th>{{ transactions("November", 2018, null) }}</th>
                    <th>{{ transactions("December", 2018, null) }}</th>
                    <th>{{ transactions(null, 2018, null) }}</th>
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
    computed: {
        categories() {
            return this.$store.getters.categories
        }
    },
    methods: {
        transactions(month, year, category) {
            console.log("Month " + month + " Year: " + year + " Category: " + category)
            const reducer = (accumulator, currentValue) => accumulator[amount] + currentValue
            console.log(kendo.toString(kendo.parseDate(this.$store.getters.transactions[0].transactionDate), "yyyy"))
            console.log(kendo.toString(kendo.parseDate(this.$store.getters.transactions[0].transactionDate), "MMMM"))
            let trans = this.$store.getters.transactions
            if(month !== null) {
                trans = trans.filter(x => kendo.toString(kendo.parseDate(x.transactionDate), "MMMM") == month)
            }
            if(year !== null) {
                trans = trans.filter(x => kendo.toString(kendo.parseDate(x.transactionDate), "yyyy") == year)
            }
            if(category !== null) {
                trans = trans.filter(x => x.budgetCategoryId == category)
            }

            if(trans.length > 0) {
                let total = trans.sum("amount")
                console.log(trans)
                return kendo.toString(total, "c")
            } else {
                return  kendo.toString(0, "c")
            }
        }
    },

    async created() {
        // ES2017 async/await syntax via babel-plugin-transform-async-to-generator
        // TypeScript can also transpile async/await down to ES5

        Array.prototype.sum = function (prop) {
            var total = 0
            for ( var i = 0, _len = this.length; i < _len; i++ ) {
                total += this[i][prop]
            }
            return total
        }
        
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