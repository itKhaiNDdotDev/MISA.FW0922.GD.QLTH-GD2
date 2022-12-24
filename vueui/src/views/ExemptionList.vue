<template>
    <div class="content__view">
        <ExemptionToolbar @onOpenForm="setShowForm(true)" @setTableStudentViewMode="setTableStudentViewMode"/>
        <ExemptionTable ref="table" @setTotalRecord="setTotalRecord"/>
        <ExemptionPaging :totalRecord="totalRecord" @setPageIndex="setPageIndex"/>
        <ExemptionForm v-if="isShowForm" @onClose="setShowForm(false)"/>
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
            isShowForm: false,
            isTableStudentViewMode: true,
            pageIndex: 1,
            totalRecord: 0
        }
    },

    methods: {
        /**
         * Khi có sự kiện yêu cầu đóng/mở Form thì tiến hành set giá trị isShowForm tương ứng tạo/hủy DOM của Form (bằng v-if)
         * @param {Boolean} value - Có mở Form hay ngược lại (đóng Form)?
         * Author: KhaiND (13/12/2022)
         */
        setShowForm(value) {
            try {
                this.isShowForm = value;
            }
            catch(error) {
                console.log(error);
                // Gửi STATE lỗi về cha
            }
        },

        /**
         * Thực hiện set giá trị cho data isTableStudentViewMode dùng chung - mode dữ liệu bảng danh sách phân trang thoogn tin miễn giảm có phải là xem theo Học sinh hay không (xem theo Khoản thu)?
         * @param {Boolean} value - Giá trị truyền vào set cho isTableStudentViewMode: true (đúng, xem theo Học sinh), false (không, xem theo Khoản thu)
         * Author: KhaiND (24/12/2022)
         */
        setTableStudentViewMode(value) {
            try {
                this.isTableStudentViewMode = value;
            }
            catch(error) {
                console.log(error);
                // Gửi STATE báo lỗi về cha 
            }
        },

        /**
         * Thực hiện set giá trị số trang hiện tại cho data pageIndex dùng chung
         * @param {Number} value - giá trị số trang hiện tại nhận đựuọc
         * Author: KhaiND (24/12/2022)
         */
        setPageIndex(value) {
            try {
                this.pageIndex = value;
            }
            catch(error) {
                console.log(error);
                // Gửi STATE báo lỗi về cha 
            }
        },

        /**
         * Thực hiện set giá trị tổng số bản ghi (load dữ liệu này Component ExemptionTable sang)
         * @param {Number} value - giá trị tổng số bản ghi bind được
         * Author: KhaiND (24/12/2022)
         */
        setTotalRecord(value) {
            try {
                this.totalRecord = value;
            }
            catch(error) {
                console.log(error);
                // Gửi STATE báo lỗi về cha
            }
        },
    },

    watch: {
        /**
         * Theo dõi khi giá trị của isTableStudentViewMode thay đổi thì gọi yêu cầu Component ExemptionTable load dữ liệu theo API tương ứng
         * @param {Boolean} value - Mode xem dữ liệu phân trang của bảng có phải xem theo Học sinh hay không? - Giá trị: true (xem theo Học sinh), false (xem theo Khoản thu)
         * Author: KhaiND (23/12/2022)
         */
        isTableStudentViewMode(value) {
            try {
                this.$refs.table.onLoadStudentExemptionList(value, this.pageIndex);
            }
            catch(error) {
                console.log(error);
                // Gửi Sate báo lỗi về component cha
            }
        },

        /**
         * Theo dõi khi giá trị của pageIndex thay đổi thì gọi yêu cầu Component StudentExemption load dữ liệu theo API tương ứng
         * @param {Number} value - Số trang hiện tại muốm load dữ liệu về từ API
         * Author: KhaiND (23/12/2022)
         */
        pageIndex(value) {
            try {
                this.$refs.table.onLoadStudentExemptionList(this.isTableStudentViewMode, value);
            }
            catch(error) {
                console.log(error);
                // Gửi Sate báo lỗi về component cha
            }
        }
    }
}
</script>

<style>
</style>