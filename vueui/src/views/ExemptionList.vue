<template>
    <div class="content__view">
        <ExemptionToolbar @onOpenForm="onOpenForm" @loadTableData="loadTableData"/>
        <ExemptionTable ref="table"/>
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
        },

        /**
         * Gọi đến Component con ExemptionTable yêu cầu load dữ liệu theo API tương ứng view mode
         * @param {Boolean} studentViewMode - mode bảng dữ liệu danh sách miễn giảm phân trang "Xem theo" Học sinh hay không (xem theo Khoản thu)? - Giá trị: true (đúng, xem theo Học sinh), false(không, xem theo Khoản thu)
         * @param {Number} pageIndex - số trang hiện tại muốn load dữ liệu tương ứng
         * Author: KhaiND (23/12/2022)
         */
        loadTableData(studentViewMode, pageIndex) {
            this.$refs.table.onLoadStudentExemptionList(studentViewMode, pageIndex)
        }
    },
}
</script>

<style>
</style>