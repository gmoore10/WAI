<template>
    <div>
        <h1>Budget Categories</h1>

        <p>Review your budgets and Spend</p>

        <form v-on:submit.prevent="addCategory" action="" method="post">
            <h2>Add Category</h2>
            <input type="text" name="categoryName" id="categoryName" v-model="insertedCategoryName" ref="insertedCategoryName">
            <button type="submit">Add Category</button>
        </form>

        <button type="button" id="addCategoryButton">Add Category</button>

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
                <tr v-for="category in categories" v-bind:key="category.id">
                    <td>{{ category.name }}</td>
                    <td>${{ category.budgeted }}</td>
                    <td>${{ category.remaining }}</td>
                    <td>${{ category.avgspend }}</td>
                </tr>
            </tbody>
        </table>
        
    </div>
</template>

<script>
export default {
    data() {
        return {
            forecasts: null,
            insertedCategoryName: "",
            categories: [
                {id: 1, name: "Mortgage", budgeted: 182.56, remaining: 117.44, avgspend: 150.41},
                {id: 2, name: "Auto Fuel", budgeted: 182.56, remaining: 117.44, avgspend: 150.41}
                // {id: 3, name: "Mortgage", budgeted: 182.56, remaining: 117.44, avgspend: 150.41},
                // {id: 4, name: "Mortgage", budgeted: 182.56, remaining: 117.44, avgspend: 150.41},
            ]
        }
    },

    methods: {
        addCategory: (event) => {
            //this.insertedCategoryName = this.$refs.insertedCategoryName
            console.log("Category Added")
            //console.log(this.insertedCategoryName)
            console.log(event.target[0].value)
        },
    },
    async created() {
        // ES2017 async/await syntax via babel-plugin-transform-async-to-generator
        // TypeScript can also transpile async/await down to ES5
        
    }
}
</script>

<style>
</style>