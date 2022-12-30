<template>
    <div class="content__view">
        <ExemptionToolbar @onOpenForm="setShowForm(true)" @onOpenImport="setShowImport(true)" @setTableStudentViewMode="setTableStudentViewMode"
            @onClickDeleteMany="onClickDeleteMany"
        />
        <ExemptionTable ref="table" @setTotalRecord="setTotalRecord" @setCurPageIndex="setPageIndex" @onOpenForm="setShowForm"/>
        <ExemptionPaging ref="paging" :totalRecord="totalRecord" @setPageIndex="setPageIndex"/>
        <ExemptionForm v-if="isShowForm" @onClose="setShowForm(false)" :selectedStudentID="selectedStudentID"/>
        <ExemptionImport v-if="isShowImport" @onClose="setShowImport(false)"/>
        <MDialog v-if="isShowDialog" :haveBtnClose="haveCloseDialog" :dialogMsg="dialogMsg" @onClose="isShowDialog=false" @onConfirm="onConfirmDialog"/>
    </div>
</template>

<script>
import ExemptionToolbar from "./exemption/ExemptionToolbar.vue";
import ExemptionTable from "./exemption/ExemptionTable.vue";
import ExemptionPaging from "./exemption/ExemptionPaging.vue";
import ExemptionForm from "./exemption/ExemptionForm.vue";
import ExemptionImport from "./exemption/ExemptionImport.vue"
import MDialog from "./../components/base/MDialog.vue";
import ExemptionResources from "./../utils/resources/exemption"

export default {
    name: "ExemptionList",
    components: {
        ExemptionToolbar,
        ExemptionTable,
        ExemptionPaging,
        ExemptionForm,
        ExemptionImport,
        MDialog
    },

    data() {
        return {
            confirmMessage: ExemptionResources.ConfirmMessage,
            isShowForm: false,
            isShowImport: false,
            isTableStudentViewMode: true,
            pageIndex: 1,
            totalRecord: 0,
            isShowDialog: false,
            deleteManyMode: 0,
            dialogMsg: "",
            selectedStudentID: null,
            haveCloseDialog: true
        }
    },

    methods: {
        /**
         * Khi có sự kiện yêu cầu đóng/mở Form chi tiết miễn giảm thì tiến hành set giá trị isShowForm tương ứng tạo/hủy DOM của Form (bằng v-if)
         * @param {Boolean} value - Có mở Form hay ngược lại (đóng Form)?
         * @param {Guid} studentID - ID của Học sinh muốn xem chi tiết
         * Author: KhaiND (13/12/2022)
         */
        setShowForm(value, studentID) {
            try {
                this.isShowForm = value;
                this.selectedStudentID = studentID;
            }
            catch(error) {
                console.log(error);
                // Gửi STATE lỗi về cha
            }
        },

        /**
         * Khi có sự kiện yêu cầu đóng/mở Form Nhập khẩu thì tiến hành set giá trị isShowImport tương ứng tạo/hủy DOM của Form Nhập khẩu (bằng v-if)
         * @param {Boolean} value - Có mở Form Nhập khẩu hay ngược lại (đóng Form)?
         * Author: KhaiND (30/12/2022)
         */
        setShowImport(value) {
            try {
                this.isShowImport = value;
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

        /**
         * Sự kiện khi người dùng bấm nút xóa nhiều thì kiểm tra danh sách chọn và hiển thị Dialog tương ứng
         * Author: KhaiND (28/12/2022)
         */
        onClickDeleteMany() {
            try {
                // Kiểm tra danh sách chọn
                if (this.$refs.table.getSlectedIDs() == null || this.$refs.table.getSlectedIDs().length <= 0) {
                    this.dialogMsg = this.confirmMessage.NotSelected;
                    this.haveCloseDialog = false;
                    this.isShowDialog = true;
                    this.deleteManyMode = 0;
                }
                else {
                    // Hiển thị Dialog
                    this.dialogMsg = this.confirmMessage.DeleteMany;
                    this.haveCloseDialog = true;
                    this.isShowDialog = true;
                    // Gọi đúng API
                    this.deleteManyMode = 1;
                }
            }
            catch(error) {
                console.log(error);
                //this.$emit("showToast", this.toastMsg.Error500, ResultStatus.FAIL);
            }
        },

        /**
         * Sự kiện khi bấm Confirm ở Dialog (Xét trường hợp xóa nhiều)
         * Author: KhaiND (28/12/2022)
         */
        onConfirmDialog() {
            // Nếu là confirm xóa nhiều
            if(this.deleteManyMode) {
                this.$refs.table.onDeleteManyExemption();
                this.isShowDialog = false;
            } // Nếu không thì đóng Dialog
            else {
                this.isShowDialog = false;
            }
        }
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
                this.$refs.paging.getPageIndex(value);
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