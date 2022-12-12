<template>
    <div class="content__view">
        <ExemptionToolbar/>
        <ExemptionTable/>
        <ExemptionPaging/>
        <ExemptionForm/>
    </div>
</template>

<script>
import ExemptionToolbar from "./exemption/ExemptionToolbar.vue";
import ExemptionTable from "./exemption/ExemptionTable.vue";
import ExemptionPaging from "./exemption/ExemptionPaging.vue";
import ExemptionForm from "./exemption/ExemptionForm.vue"

export default {
    name: "ExemptionList",
    components: {
        ExemptionToolbar,
        ExemptionTable,
        ExemptionPaging,
        ExemptionForm
    }
}
</script>

<style>
</style>