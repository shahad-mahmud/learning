class Node():
    def __init__(self, data):
        self.data = data
        self.next = None


class LinkedList():
    def __init__(self):
        self.head = None


    def add(self, data):
        if self.head == None:
            self.head = Node(data)
            return
        
        newNode = Node(data)
        curNode = self.head
        # prevNode = self.head

        while(curNode.next != None):
            curNode = curNode.next
        
        curNode.next = newNode

    
    def printList(self):
        curNode = self.head

        while(curNode != None):
            print(curNode.data)
            curNode = curNode.next


if __name__ == '__main__':
    linked_list = LinkedList()
    linked_list.add(2)
    linked_list.add(3)
    linked_list.add(4)

    linked_list.printList()


