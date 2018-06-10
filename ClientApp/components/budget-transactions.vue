<template>
    <div>
        <h1>Transactions</h1>

        <p>Go over and add transactions</p>

        <button type="button" id="addTransactionButton" v-if="!addTransactionFormVisible" v-on:click="addTransactionFormVisible = !addTransactionFormVisible">Add Transaction</button>

        <form v-else-if="addTransactionFormVisible" v-on:submit.prevent="addTransaction" action="" method="post">
            <h2>Add Category</h2>
            <label for="transactionName">Name: </label>
            <input type="text" name="transactionName" required id="transactionName" v-model="insertedTransactionName" ref="insertedTransactionName">
            <label for="transactionAmount">Amount: </label>
            <input type="text" name="transactionAmount" required id="transactionAmount" v-model="insertedTransactionAmount" ref="insertedTransactionAmount">
            
            <kendo-datepicker required
                      :value="currentDate"
                      :format="'MM/dd/yyyy'"
                      v-model="insertedDate">
            </kendo-datepicker>

            <button type="submit">Add Category</button>
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
                    :width="250">
                </kendo-grid-column>
                <kendo-grid-column
                    field="date"
                    title="Date">
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
                    :command="['edit', 'destroy']">
                </kendo-grid-column>
            </kendo-grid>
        </div>

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
                <tr v-for="transaction in transactions" v-bind:key="transaction.id">
                    <td>{{ transaction.name }}</td>
                    <td>{{ convertDate(transaction.date) }}</td>
                    <td>{{ convertCurrency(transaction.amount) }}</td>
                    <td>{{ convertCurrency(transaction.budgetRemaining) }}</td>
                </tr>
            </tbody>
        </table>
        
    </div>
</template>

<script>
export default {
    data() {
        return {
            addTransactionFormVisible: false,
            insertedTransactionName: "",
            insertedTransactionAmount: null,
            insertedDate: new Date(),
            currentDate: new Date()
        }
    },
    computed: {
        transactions() {
            return this.$store.getters.transactions
        }
    },

    methods: {
        addTransaction () {
            let newTrans = { id: Math.floor(Math.random() * 1000000), name: this.insertedTransactionName, date: this.insertedDate, amount: this.insertedTransactionAmount }
            this.$store.commit('addTransaction', newTrans)
        },
        convertDate(date) {
            return kendo.toString(date, "d")
        },
        convertCurrency(value) {
            return kendo.toString(value, "c");
        },
        transactionsJSON() {
            return JSON.stringify(this.$store.getters.transactions)
        },
        onSave(ev) {
            console.log(ev)
            ev.sender.refresh()
        },
        onRemove(ev) {
            console.log(ev)
            ev.sender.refresh()
            this.$store.commit('deleteTransaction', ev.model.id)
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