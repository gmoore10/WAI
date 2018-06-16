<template>
    <kendo-combobox 
        :data-source="categories"
        :data-text-field="'name'"
        :data-value-field="'id'"
        :filter="'contains'"
        v-on:change="onChange"
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
    },
    methods: {
        onChange(value) {
            this.$emit('itemChanged', value)
        }
    }
}
</script>

<style>
</style>
