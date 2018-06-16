import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

// TYPES
const MAIN_SET_COUNTER = 'MAIN_SET_COUNTER'

// STATE
const state = {
    categories: [
        {id: 1, name: "Mortgage", budgeted: 182.56, remaining: 117.44, avgspend: 150.41},
        {id: 2, name: "Auto Fuel", budgeted: 182.56, remaining: 117.44, avgspend: 150.41}
    ],
    transactions: [
        { id: 1, name: "Publix Trip", date: "4/6/2018", category: 1, amount: 182.56, budgetRemaining: 117.44 },
        { id: 2, name: "Weekend Party", date: "4/9/2018", category: 2, amount: 441.22, budgetRemaining: -323.78 },
        { id: 3, name: "Weekend Party", date: "4/9/2018", category: 2, amount: 150.00, budgetRemaining: -473.78 }
    ]
}

// MUTATIONS
const mutations = {
    addCategory(state, newCat) {
        this.state.categories.push(newCat)
    },
    editCategory(state, editedCat) {
        const cat = state.categories.find(cat => {
            return cat.id == editedCat.id
        })

        state.categories.splice(state.categories.indexOf(cat), 1, editedCat)
    },
    deleteCategory(state, deletedId) {
        const cat = state.categories.find(cat => {
            return cat.id == deletedId
        })

        state.categories.splice(state.categories.indexOf(cat), 1)
    },
    addTransaction(state, newTrans) {
        this.state.transactions.push(newTrans)
    },
    editTransaction(state, editedTrans) {
        const trans = state.transactions.find(trans => {
            return trans.id == editedTrans.id
        })

        state.transactions.splice(state.transactions.indexOf(trans), 1, editedTrans)
    },
    deleteTransaction(state, deletedId) {
        const trans = state.transactions.find(trans => {
            return trans.id == deletedId
        })
        state.transactions.splice(state.transactions.indexOf(trans), 1)
    }
}

// ACTIONS
const actions = ({
})

// GETTERS
const getters = {
    categories: state => state.categories,
    transactions: state => state.transactions
}

export default new Vuex.Store({
    state,
    mutations,
    actions,
    getters: getters
});
