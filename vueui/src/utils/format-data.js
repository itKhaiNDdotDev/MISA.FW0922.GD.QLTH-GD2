/**
 * Định dạng dữ liệu ngày về DD/MM/YYYY
 * @param {*} date 
 * @returns ngày đã được định dạng thành string tương ứng
 * Author: KhaiND (26/12/2022)
 */
export function formatDate(date) {
    if (date) {
        date = new Date(date);
        let dd = date.getDate();
        dd = dd < 10 ? "0" + dd : dd;
        let mm = date.getMonth() + 1;
        mm = mm < 10 ? "0" + mm : mm;
        let yyyy = date.getFullYear();
        date = dd + "/" + mm + "/" + yyyy;
    }
    else {
        date = "";
    }
    return date;
}