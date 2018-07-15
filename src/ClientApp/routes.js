import BudgetCategories from 'components/budget-categories'
import BudgetTransactions from 'components/budget-transactions'
import ReportsAnnual from 'components/reports-annual'
import ReportsCurrentMonth from 'components/reports-currentmonth'

export const routes = [
    { path: '/', component: BudgetCategories, display: 'Categories', style: 'glyphicon glyphicon-home'},
    { path: '/budget-transactions', component: BudgetTransactions, display: 'Transactions', style: 'glyphicon glyphicon-education' },
    { path: '/reports', component: ReportsCurrentMonth, display: 'Current Month Spend', style: 'glyphicon glyphicon-th-list' },
    { path: '/reports-annual', component: ReportsAnnual, display: 'Annual Spend', style: 'glyphicon glyphicon-th-list' }
]