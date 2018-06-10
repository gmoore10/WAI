<template>
    <div>
        <h1>Budget Categories</h1>

        <p>Review your budgets and Spend</p>

        <button type="button" id="addCategoryButton" v-if="!addCategoryFormVisible" v-on:click="addCategoryFormVisible = !addCategoryFormVisible">Add Category</button>

        <form v-else-if="addCategoryFormVisible" v-on:submit.prevent="addCategory" action="" method="post">
            <h2>Add Category</h2>
            <label for="categoryName">Name: </label>
            <input type="text" name="categoryName" id="categoryName" v-model="insertedCategoryName" ref="insertedCategoryName">
            <label for="categoryBudgeted">Budgeted: </label>
            <input type="text" name="categoryBudgeted" id="categoryBudgeted" v-model="insertedCategoryBudgeted" ref="insertedCategoryBudgeted">
            <button type="submit">Add Category</button>
            <button type="button" v-on:click="addCategoryFormVisible = !addCategoryFormVisible">Cancel</button>
        </form>


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
            addCategoryFormVisible: false,
            insertedCategoryName: "",
            insertedCategoryBudgeted: 0.00
        }
    },
    computed: {
        categories() {
            return this.$store.getters.categories
        }
    },

    methods: {
        addCategory () {
            let newCat = { id: Math.floor(Math.random() * 1000000), name: this.insertedCategoryName, budgeted: this.insertedCategoryBudgeted, remaining: 0.00, avgspend: 0.00 }
            this.$store.commit('addCategory', newCat)
        }
    },
    async created() {
        // ES2017 async/await syntax via babel-plugin-transform-async-to-generator
        // TypeScript can also transpile async/await down to ES5
        console.log(this.categories)
    }
}
</script>

<style>
</style>