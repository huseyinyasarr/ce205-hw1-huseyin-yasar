#include "CppUnitTest.h"
#include "..\mylibcpp\mydata.h"
#include "..\mylibcpp\myqueue.h"
#include "..\mylibcpp\mystack.h"
#include "../mylibcpp/mysparsematrix.h"
#include "../mylibcpp/mysparsematrix.cpp"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace mylibcpptest
{
	TEST_CLASS(mylibcppteststack)
	{
	public:
		
		TEST_METHOD(TestStackPushWorking)
		{
			MyStack* myStack = new MyStack();
			Data* data = new Data();
			data->key = 1;
			data->value = new char[12] {"First"};
			push(myStack, data);
			data->key = 2;
			data->value = new char[12] {"Second"};
			push(myStack, data);
			data->key = 3;
			data->value = new char[12] {"Third"};
			push(myStack, data);

			Assert::AreEqual(0, myStack->data);
		}

		TEST_METHOD(TestStackPopWorking)
		{
			MyStack* myStack = new MyStack();
			Data* data = new Data();
			data->key = 1;
			data->value = new char[12] {"First"};
			push(myStack, data);
			data->key = 2;
			data->value = new char[12] {"Second"};
			push(myStack, data);
			data->key = 3;
			data->value = new char[12] {"Third"};
			push(myStack, data);

			Data* dataRestored = pop(myStack);
			Assert::AreEqual(2, stackLength(myStack));
			
		}

		TEST_METHOD(TestStackTopWorking)
		{
			MyStack* myStack = new MyStack();
			Data* data = new Data();
			data->key = 1;
			data->value = new char[12] {"First"};
			push(myStack, data);
			data->key = 2;
			data->value = new char[12] {"Second"};
			push(myStack, data);
			data->key = 3;
			data->value = new char[12] {"Third"};
			push(myStack, data);
			data->key = 4;
			data->value = new char[12] {"Fourth"};
			push(myStack, data);
			data->key = 5;
			data->value = new char[12] {"Fifth"};
			push(myStack, data);

			Data* result = top(myStack);
			Assert::AreEqual(5, result->key);
		}

		TEST_METHOD(TestStackBottomWorking)
		{
			MyStack* myStack = new MyStack();
			Data* data = new Data();
			data->key = 1;
			data->value = new char[12] {"First"};
			push(myStack, data);
			data->key = 2;
			data->value = new char[12] {"Second"};
			push(myStack, data);
			data->key = 3;
			data->value = new char[12] {"Third"};
			push(myStack, data);
			data->key = 4;
			data->value = new char[12] {"Fourth"};
			push(myStack, data);
			data->key = 5;
			data->value = new char[12] {"Fifth"};
			push(myStack, data);
			
			Data* result = bottom(myStack);
			Assert::AreEqual(1, result->key);
		}

		TEST_METHOD(TestStackLengthWorking)
		{
			MyStack* myStack = new MyStack();
			Data* data = new Data();
			data->key = 1;
			push(myStack, data);
			data->key = 2;
			push(myStack, data);
			data->key = 3;
			push(myStack, data);
			data->key = 4;
			push(myStack, data);
			data->key = 5;
			push(myStack, data);
			int resultLength = stackLength(myStack);
			Assert::AreEqual(5, resultLength);
		}

	};

	TEST_CLASS(mylibcpptestqueue)
	{
	public:

		TEST_METHOD(TestQueueEnqueueWorking)
		{
			MyQueue* myQueue = (MyQueue*)malloc(sizeof(MyQueue));
			Data* data = (Data*)malloc(sizeof(Data));
			data->key = 1;
			enqueue(myQueue, data);
			data->key = 2;
			enqueue(myQueue, data);
			data->key = 3;
			enqueue(myQueue, data);
			data->key = 4;
			enqueue(myQueue, data);

			Assert::AreEqual(11, queueLength(myQueue));
		}

		TEST_METHOD(TestQueueDequeueWorking)
		{
			MyQueue* myQueue = (MyQueue*)malloc(sizeof(MyQueue));
			Data* data = (Data*)malloc(sizeof(Data));
			data->key = 1;
			enqueue(myQueue, data);
			data->key = 2;
			enqueue(myQueue, data);
			data->key = 3;
			enqueue(myQueue, data);
			data->key = 4;
			enqueue(myQueue, data);
			dequeue(myQueue);

			Assert::AreEqual(7, queueLength(myQueue));
		}

		TEST_METHOD(TestQueueFrontWorking)
		{
			MyQueue* myQueue = (MyQueue*)malloc(sizeof(MyQueue));
			Data* data = (Data*)malloc(sizeof(Data));
			data->key = 1;
			enqueue(myQueue, data);

			Data* result = front(myQueue);

			Assert::AreEqual(2, result->key);
		}

		TEST_METHOD(TestQueueBackWorking)
		{
			MyQueue* myQueue = (MyQueue*)malloc(sizeof(MyQueue));
			Data* data = (Data*)malloc(sizeof(Data));
			data->key = 1;
			enqueue(myQueue, data);
			data->key = 2;
			enqueue(myQueue, data);
			data->key = 3;
			enqueue(myQueue, data);
			data->key = 4;
			enqueue(myQueue, data);

			Data* result = back(myQueue);

			Assert::AreEqual(4, result->key);
		}

		TEST_METHOD(TestQueueLengthWorking)
		{
			MyQueue* myQueue = (MyQueue*)malloc(sizeof(MyQueue));
			Data* data = (Data*)malloc(sizeof(Data));
			data->key = 1;
			enqueue(myQueue, data);
			data->key = 2;
			enqueue(myQueue, data);
			data->key = 3;
			enqueue(myQueue, data);
			data->key = 4;
			enqueue(myQueue, data);
			

			int result = queueLength(myQueue);

			Assert::AreEqual(16, result);
		}
	};

	TEST_CLASS(mylibcpptestsparsematrix)
	{
	public:

		TEST_METHOD(TestSparseMatrixInsertWorking)
		{
			MySparseMatrix* matrix = initSparseMatrix(3, 3);
			Data* data = new Data();
			data->key = 1;
			insertSparseMatrix(matrix, 0, 0, data);
			data->key = 2;
			insertSparseMatrix(matrix, 0, 1, data);
			data->key = 3;
			insertSparseMatrix(matrix, 0, 2, data);
			data->key = 4;
			insertSparseMatrix(matrix, 1, 0, data);
			data->key = 5;
			insertSparseMatrix(matrix, 1, 1, data);
			data->key = 6;
			insertSparseMatrix(matrix, 1, 2, data);
			data->key = 7;
			insertSparseMatrix(matrix, 2, 0, data);
			data->key = 8;
			insertSparseMatrix(matrix, 2, 1, data);
			data->key = 9;
			insertSparseMatrix(matrix, 2, 2, data);
			

			Assert::AreEqual(10, lengthMatrix(matrix));
		}

		TEST_METHOD(TestSparseMatrixGetWorking)
		{
			MySparseMatrix* matrix = initSparseMatrix(3, 3);
			Data* data = new Data();
			data->key = 1;
			insertSparseMatrix(matrix, 0, 0, data);
			data->key = 2;
			insertSparseMatrix(matrix, 0, 1, data);
			data->key = 3;
			insertSparseMatrix(matrix, 0, 2, data);
			data->key = 4;
			insertSparseMatrix(matrix, 1, 0, data);
			data->key = 5;
			insertSparseMatrix(matrix, 1, 1, data);
			data->key = 6;
			insertSparseMatrix(matrix, 1, 2, data);
			data->key = 7;
			insertSparseMatrix(matrix, 2, 0, data);
			data->key = 8;
			insertSparseMatrix(matrix, 2, 1, data);
			data->key = 9;
			insertSparseMatrix(matrix, 2, 2, data);

			Data* result = getSparseMatrix(matrix, 0, 1);
			Assert::AreEqual(2, result->key);
		}

		TEST_METHOD(TestSparseMatrixDeleteWorking)
		{
			MySparseMatrix* matrix = initSparseMatrix(3, 3);
			Data* data = new Data();
			data->key = 1;
			insertSparseMatrix(matrix, 0, 0, data);
			data->key = 2;
			insertSparseMatrix(matrix, 0, 1, data);
			data->key = 3;
			insertSparseMatrix(matrix, 0, 2, data);
			data->key = 4;
			insertSparseMatrix(matrix, 1, 0, data);
			data->key = 5;
			insertSparseMatrix(matrix, 1, 1, data);
			data->key = 6;
			insertSparseMatrix(matrix, 1, 2, data);
			data->key = 7;
			insertSparseMatrix(matrix, 2, 0, data);
			data->key = 8;
			insertSparseMatrix(matrix, 2, 1, data);
			data->key = 9;
			insertSparseMatrix(matrix, 2, 2, data);

			deleteSparseMatrix(matrix, 0, 1);

			Assert::AreEqual(9, lengthMatrix(matrix));
		}
		TEST_METHOD(TestSparseMatrixCopyWorking)
		{
			MySparseMatrix* matrix = initSparseMatrix(3, 3);
			Data* data = new Data();
			data->key = 1;
			insertSparseMatrix(matrix, 0, 0, data);
			data->key = 2;
			insertSparseMatrix(matrix, 0, 1, data);
			data->key = 3;
			insertSparseMatrix(matrix, 0, 2, data);
			data->key = 4;
			insertSparseMatrix(matrix, 1, 0, data);
			data->key = 5;
			insertSparseMatrix(matrix, 1, 1, data);
			data->key = 6;
			insertSparseMatrix(matrix, 1, 2, data);
			data->key = 7;
			insertSparseMatrix(matrix, 2, 0, data);
			data->key = 8;
			insertSparseMatrix(matrix, 2, 1, data);
			data->key = 9;
			insertSparseMatrix(matrix, 2, 2, data);

			//MySparseMatrix* matrixCopy = initSparseMatrix(3, 3);
			//copySparseMatrix(matrix, matrixCopy);

			//Assert::AreEqual(10, lengthMatrix(matrixCopy));
		}
	};
}
