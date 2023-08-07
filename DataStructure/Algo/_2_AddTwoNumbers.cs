namespace DataStructure.Algo;

public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class _2_AddTwoNumbers
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var dummy = new ListNode(0);
        var current = dummy;
        int carry = 0; //进位值

        while (l1 != null || l2 != null)
        {
            int x = (l1 != null) ? l1.val : 0;
            int y = (l2 != null) ? l2.val : 0;
            int sum = x + y + carry;
            carry = sum / 10; //算出进位值
            current.next = new ListNode(sum % 10); // 创建新节点，并将个位数作为节点值
            current = current.next;

            if (l1 != null) l1 = l1.next;
            if (l2 != null) l2 = l2.next;
        }

        if (carry > 0)
        {
            current.next = new ListNode(carry);
        }

        return dummy.next;
    }

    public static void Test()
    {
        ListNode l1 = new ListNode(2);
        l1.next = new ListNode(4);
        l1.next.next = new ListNode(3);

        ListNode l2 = new ListNode(5);
        l2.next = new ListNode(6);
        l2.next.next = new ListNode(4);

        var addTwoNumbers = new _2_AddTwoNumbers().AddTwoNumbers(l1, l2);
    }
}