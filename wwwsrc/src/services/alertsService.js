import Swal from "sweetalert2"
export default class NotificationService {
    static async confirmAction(text = "You won't be able to revert this!") {
        try {
            let res = await Swal.fire({
                title: "Are You Sure?",
                text: "You won't be able to undo this!",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonText: 'Yes, delete it!'
            })
            if (res.value) {
                return true
            }
            return false
        } catch (error) {

        }
    }
}