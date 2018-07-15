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
        labeltemplate: '#= category # $#= value #',
        seriesColors: ["#76323F", "#AE3644", "#FF6C88", "#401B22", "#E57F7B"],
        series: [{
            type: 'pie',
            startAngle: 150,
            data: []
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
    },
    updateChartData(state, chartData) {
        state.chartOptions.series[0].data = []
        Array.from(chartData).forEach(function(element) {
            state.chartOptions.series[0].data.push(element)
        })
    }
}

// ACTIONS
const actions = ({
    async updateChartData() {
        try {
            let response = await axios.get('/api/reports')
            console.log(response)
            this.commit('updateChartData', response.data)
        } catch (err) {
            console.log(err)
        }
    },
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
    },
    async addBudgetTransaction(state, newTrans) {
        try {
            let response = await axios.post('/api/budgettransaction', newTrans)
            console.log(response)
        } catch (err) {
            alert(err)
            console.log(err)
        }
    },
    async editBudgetTransaction(state, editedTrans) {
        try {
            let response = await axios.put('/api/budgettransaction', editedTrans)
            console.log(response)
        } catch (err) {
            alert(err)
            console.log(err)
        }
    },
    async addBudgetCategory(state, newCat) {
        try {
            let response = await axios.post('/api/budgetcategory', newCat)
            console.log(response)
        } catch (err) {
            alert(err)
            console.log(err)
        }
    },
    async editBudgetCategory(state, editedCat) {
        try {
            let response = await axios.put('/api/budgetcategory', editedCat)
            console.log(response)
        } catch (err) {
            alert(err)
            console.log(err)
        }
    },
    async deleteBudgetCategory(state, deletedCat) {
        try {
            let response = await axios.delete('/api/budgetcategory/' + deletedCat)
            console.log(response)
        } catch (err) {
            alert(err)
            console.log(err)
        }
    },
    async deleteBudgetTransaction(state, deletedTrans) {
        try {
            let response = await axios.delete('/api/budgettransaction/' + deletedTrans)
            console.log(response)
        } catch (err) {
            alert(err)
            console.log(err)
        }
    }
})

// GETTERS
const getters = {
    categories: state => state.categories,
    transactions: state => state.transactions,
    chartOptions: state => state.chartOptions
}

export default new Vuex.Store({
    state,
    mutations,
    actions,
    getters: getters
});
