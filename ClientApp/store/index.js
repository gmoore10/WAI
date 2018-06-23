import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

// TYPES
const MAIN_SET_COUNTER = 'MAIN_SET_COUNTER'

// STATE
const state = {
    categories: [
    ],
    transactions: [
    ],
    chartOptions: {
        labeltemplate: '#= category # #= value #%',
        series: [{
            type: 'pie',
            startAngle: 150,
            data: [{
                category: 'Asia',
                value: 53.8,
                color: '#9de219'
            },
            {
                category: 'Europe',
                value: 16.1,
                color: '#90cc38'
            },
            {
                category: 'Latin America',
                value: 11.3,
                color: '#068c35'
            },
            {
                category: 'Africa',
                value: 9.6,
                color: '#006634'
            },
            {
                category: 'Middle East',
                value: 5.2,
                color: '#004d38'
            },
            {
                category: 'North America',
                value: 3.6,
                color: '#033939'
            }]
        }]
    }
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
    },
    getBudgetCategories(state, allCats) {
        state.categories = []
        Array.from(allCats).forEach(function(element) {
            state.categories.push(element)
        })
    },
    getTransactions(state, allTrans) {
        state.transactions = []
        Array.from(allTrans).forEach(function(element) {
            state.transactions.push(element)
        })
    }
}

// ACTIONS
const actions = ({
    async getBudgetCategories() {
        try {
            let response = await axios.get('/api/budgetcategory')
            this.commit('getBudgetCategories', response.data)
        }
        catch (err) {
            console.log(err)
        }
    },
    async getTransactions() {
        try {
            let response = await axios.get('/api/budgettransaction')
            this.commit('getTransactions', response.data)
        }
        catch (err) {
            console.log(err)
        }
    }
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
