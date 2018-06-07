import FetchData from 'components/fetch-data'
import BudgetCategories from 'components/budget-categories'
import BudgetTransactions from 'components/budget-transactions'

export const routes = [
    { path: '/', component: BudgetCategories, display: 'Home', style: 'glyphicon glyphicon-home' },
    { path: '/budget-transactions', component: BudgetTransactions, display: 'Transactions', style: 'glyphicon glyphicon-education' },
    { path: '/fetch-data', component: FetchData, display: 'Fetch data', style: 'glyphicon glyphicon-th-list' }
]