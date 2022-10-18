#include "myqueue.h"
#include <malloc.h>

#pragma region QUEUE FUNCTIONS
/// <summary>
/// 
/// </summary>
MyQueue* head = NULL;
MyQueue* tail = NULL;

int enqueue(MyQueue* myQueue, Data* data) {
	/// <summary>
	/// to create a new linked list node
	/// </summary>
	/// <param name="myQueue"></param>
	/// <param name="data"></param>
	/// <returns></returns>
	MyQueue* temp = (MyQueue*)malloc(sizeof(MyQueue));
	temp->data = data->key;
	temp->next = NULL;
	/// <summary>
	/// if queue is empty then new node is front and rear both
	/// </summary>
	/// <param name="myQueue"></param>
	/// <param name="data"></param>
	/// <returns></returns>
	if (head == NULL && tail == NULL) {
		head = tail = temp;
		return 1;
	}
	/// <summary>
	/// add the new node at the end of queue and change rear
	/// </summary>
	/// <param name="myQueue"></param>
	/// <param name="data"></param>
	/// <returns></returns>
	tail->next = temp;
	tail = temp;
	return 1;
}
/// <summary>
/// to remove item in queue
/// </summary>
/// <param name="myQueue"></param>
/// <returns></returns>
Data* dequeue(MyQueue* myQueue) {
	Data* data = (Data*)malloc(sizeof(Data));
	/// <summary>
	/// if queue is empty, return null.
	/// </summary>
	/// <param name="myQueue"></param>
	/// <returns></returns>
	if (head == NULL) {
		return NULL;
	}
	/// <summary>
	/// store previous front and move front one node ahead
	/// </summary>
	/// <param name="myQueue"></param>
	/// <returns></returns>
	if (head == tail) {
		data->key = head->data;
		head = tail = NULL;
		return data;
	}
	data->key = head->data;
	MyQueue* temp = head;
	head = head->next;
	delete(temp);
	return data;
}
/// <summary>
/// to get front item in queue
/// </summary>
/// <param name="myQueue"></param>
/// <returns></returns>
Data* front(MyQueue* myQueue) {
	Data* data = (Data*)malloc(sizeof(Data));
	if (front == NULL) {
		return NULL;
	}
	data->key = head->data;
	return data;
}
/// <summary>
/// to get rear item in queue
/// </summary>
/// <param name="myQueue"></param>
/// <returns></returns>
Data* back(MyQueue* myQueue) {
	Data* data = (Data*)malloc(sizeof(Data));
	if (back == NULL) {
		return NULL;
	}
	data->key = tail->data;
	return data;
}
/// <summary>
/// to show all items in queue
/// </summary>
/// <param name="myQueue"></param>
/// <returns></returns>
int queueLength(MyQueue* myQueue) {
	int length = 0;
	MyQueue* temp = head;
	while (temp != NULL) {
		length++;
		temp = temp->next;
	}
	return length;
}

#pragma endregion