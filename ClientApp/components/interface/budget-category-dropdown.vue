<template>
    <kendo-combobox 
        :data-source="categories"
        :data-text-field="'name'"
        :data-value-field="'id'"
        :filter="'contains'"
        :placeholder="'Select Category...'">
    </kendo-combobox>
</template>

<script>
export default {
    data() {
        return {
        }
    },
    computed: {
        categories() {
            return this.$store.getters.categories
        }
    }
}
</script>

<style>
</style>
