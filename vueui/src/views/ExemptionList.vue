<template>
    <div class="content__view">
        <ExemptionToolbar @onOpenForm="onOpenForm"/>
        <ExemptionTable/>
        <ExemptionPaging/>
        <ExemptionForm v-if="isShowForm" @onClose="onCloseForm"/>
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
    },

    data() {
        return {
            isShowForm: false
        }
    },

    methods: {
        /**
         * Khi có sự kiện yêu cầu đóng Form thì tiến hành hủy DOM của Form
         * Author: KhaiND (13/12/2022)
         */
        onCloseForm() {
            this.isShowForm = false;
        },

        /**
         * Khi có sự kiện yêu cầu mở Form thì tiến hành tạo DOM cho Form và hiển thị
         * Author: KhaiND (13/12/2022)
         */
        onOpenForm() {
            this.isShowForm = true;
        }
    },
}
</script>

<style>
</style>