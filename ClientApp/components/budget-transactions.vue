<template>
    <div>
        <h1>Transactions</h1>

        <p>Go over and add transactions</p>

        <button type="button" id="addTransactionButton" v-if="!addTransactionFormVisible" v-on:click="addTransactionFormVisible = !addTransactionFormVisible">Add Transaction</button>

        <form v-else-if="addTransactionFormVisible" v-on:submit.prevent="addTransaction" action="" method="post">
            <h2>Add Transaction</h2>
            <label for="transactionName">Name: </label>
            <input type="text" name="transactionName" required id="transactionName" v-model="insertedTransactionName" ref="insertedTransactionName">
            <label for="transactionAmount">Amount: </label>
            <input type="text" name="transactionAmount" required id="transactionAmount" v-model="insertedTransactionAmount" ref="insertedTransactionAmount">
            
            <kendo-datepicker required
                      :value="currentDate"
                      :format="'MM/dd/yyyy'"
                      v-model="insertedDate">
            </kendo-datepicker>

            <button type="submit">Add Transaction</button>
            <button type="button" v-on:click="addTransactionFormVisible = !addTransactionFormVisible">Cancel</button>
        </form>

        <div class="grid">
            <kendo-datasource
                ref="datasource"
                :type="'json'"
                :pageSize="20"
                :data="transactions">
            </kendo-datasource>
            <kendo-grid
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
                    title="Descrip"
                    :width="150">
                </kendo-grid-column>
                <kendo-grid-column
                    field="date"
                    :format="'{0:d}'"
                    title="Date">
                </kendo-grid-column>
                <kendo-grid-column
                    field="category"                    
                    :editor="dropdownEditor"
                    :template="categoryName"
                    title="Budget Category">
                </kendo-grid-column>
                <kendo-grid-column
                    field="amount"
                    title="Amount">
                </kendo-grid-column>
                <kendo-grid-column
                    field="budgetRemaining"
                    title="Budget Remaining">
                </kendo-grid-column>
                <kendo-grid-column
                    :command="['edit', 'destroy']"
                    :width="200">
                </kendo-grid-column>
            </kendo-grid>
        </div>
        <component is="budget-category-dropdown"></component>
    </div>
</template>

<script>
import Vue from 'vue'
import BudgetCategoryDropDown from './interface/budget-category-dropdown'
export default {
    components: {
        'budget-category-dropdown': BudgetCategoryDropDown
    },
    data() {
        return {
            addTransactionFormVisible: false,
            insertedTransactionName: "",
            insertedTransactionAmount: null,
            insertedCategoryId: null,
            insertedDate: new Date(),
            currentDate: new Date()
        }
    },
    computed: {
        transactions() {
            return this.$store.getters.transactions
        },
        categories() {
            return this.$store.getters.categories
        },
    },

    methods: {
        categoryName(dataItem) {
            console.log(dataItem)
            /*console.log("Data Item: " + JSON.stringify(dataItem))
            console.log("Category ID: " + dataItem.category)*/
            console.log(dataItem.category)
            return this.$store.getters.categories.filter(x => x.id == dataItem.category)[0].name
        },
        addTransaction () {
            let newTrans = { id: Math.floor(Math.random() * 1000000), name: this.insertedTransactionName, date: this.insertedDate, amount: this.insertedTransactionAmount }
            this.$store.commit('addTransaction', newTrans)
            this.addTransactionFormVisible = false
        },
        transactionsJSON() {
            return JSON.stringify(this.$store.getters.transactions)
        },
        onSave(ev) {
            console.log(ev)
            this.$store.commit('editTransaction', { id: ev.model.id, name: ev.model.name, category: ev.model.category, date: ev.model.date, amount: ev.model.amount, budgetRemaining: ev.model.budgetRemaining})
            ev.sender.refresh()
        },
        onRemove(ev) {
            console.log(ev)
            this.$store.commit('deleteTransaction', ev.model.id)
            ev.sender.refresh()
        },
        customBoolEditor: function(container, options) {
                var guid = kendo.guid();
                kendo.jQuery('<input class="k-checkbox" id="' + guid + '" type="checkbox" name="Discontinued" data-type="boolean" data-bind="checked:Discontinued">').appendTo(container)
                kendo.jQuery('<label class="k-checkbox-label" for="' + guid + '">&#8203;</label>').appendTo(container);
        },
        dropdownEditor(container, options) {
            /*console.log(container)
            console.log(options)
            var guid = kendo.guid();
            var ComponentClass = Vue.extend(BudgetCategoryDropDown)
            var instance = new ComponentClass({ propsData: this.$store.getters.categories})
            instance.$mount()
            container.append(instance.$el)*/
            
            //component.appendTo(container)

            var guid = kendo.guid();
            
            let openSelect = '<select id="' + guid + '" name="Category" data-type="text" data-bind="value:category">'
            let selectOptions = ""

            this.categories.forEach(function(element) {
                selectOptions = selectOptions + "<option value='" + element.id + "'>" + element.name + "</option>"
            })

            let closeSelect = "</select>"

            kendo.jQuery(openSelect + selectOptions + closeSelect).appendTo(container)
            
           /*********************** FIRST WORKING VERSION ABOVE - NO COMBOBOX JUST A DROPDOWN */
            /*
            kendo.jQuery('<kendo-combobox id="' + guid +  '"data-bind="value:category"' + '":data-source="categories"' +
                    ":data-text-field=" + "'name'" + 
                    ':data-value-field="' + "'id'" + '"' +
                    'data-bind="insertedCategoryId"' +
                    ':placeholder="' + "'Select a Category'" + '"></kendo-combobox>').appendTo(container)
            */
        }
    },

    async created() {
        // ES2017 async/await syntax via babel-plugin-transform-async-to-generator
        // TypeScript can also transpile async/await down to ES5
        
    }
}
</script>

<style>
</style>