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

        
        <div class="grid">
            <kendo-datasource
                ref="datasource"
                :type="'json'"
                :pageSize="20"
                :schema-model-id="'id'"
                :schema-model-fields="schema"
                :data="categories">
            </kendo-datasource>
            <kendo-grid
                ref="grid"
                :dataSourceRef="'datasource'"
                :editable="'inline'"
                @save="onSave"
                @remove="onRemove"
                :height="550"
                :sortable="true"
                :pageable-refresh="true"
                :pageable-page-sizes="true"
                :pageable-button-count="5">
                <kendo-grid-column
                    field="name"
                    title="Name"
                    :width="250">
                </kendo-grid-column>
                <kendo-grid-column
                    field="budgeted"
                    :format="'{0:c}'"
                    title="Budgeted">
                </kendo-grid-column>
                <kendo-grid-column
                    field="remaining"
                    :format="'{0:c}'"
                    title="Remaining">
                </kendo-grid-column>
                <kendo-grid-column
                    field="avgspend"
                    :format="'{0:c}'"
                    title="Avg Spent Past 3 Months">
                </kendo-grid-column>
                <kendo-grid-column
                    :command="['edit', 'destroy']">
                </kendo-grid-column>
            </kendo-grid>
        </div>
        
    </div>
</template>

<script>
export default {
    data() {
        return {
            addCategoryFormVisible: false,
            insertedCategoryName: "",
            insertedCategoryBudgeted: 0.00,
            schema: {
                id: { editable: false, nullable: false },
                name: { validation: { required: true }},
                budgeted: { editable: true, type: 'number', validation: { required: true, min: 1 }},
                remaining: { editable: false, type: 'number' },
                avgspend: { editable: false, type: 'number' }
            }
        }
    },
    computed: {
        categories() {
            return this.$store.getters.categories
        }
    },

    methods: {
        addCategory () {
            let newCat = { id: Math.floor(Math.random() * 1000000), name: this.insertedCategoryName, budgeted: this.insertedCategoryBudgeted, remaining: this.insertedCategoryBudgeted, avgspend: 0.00 }
            this.$store.commit('addCategory', newCat)
            this.addCategoryFormVisible = false
        },
        onSave(ev) {
            console.log(ev)
            this.$store.commit('editCategory', { id: ev.model.id, name: ev.model.name, budgeted: ev.model.budgeted, remaining: ev.model.remaining, avgspend: ev.model.avgspend })
            ev.sender.refresh()
            console.log(ev.sender)
        },
        onRemove(ev) {
            console.log(ev)
            this.$store.commit('deleteCategory', ev.model.id)
            ev.sender.refresh()
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
.k-state-selected {
    background-color: #76323F !important;
    border-color: #76323F !important
}
</style>