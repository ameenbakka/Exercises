public class SecondLargest {
public static void main(String[] args) {
int[] arr = {1, 2, 3, 4, 5};
int largest = arr[0];
int secondLargest = arr[0];
for (int i = 1; i < arr.length; i++) {
if (arr[i] > largest) {
secondLargest = largest;
largest = arr[i];
} else if (arr[i] > secondLargest && arr[i] < largest) {
secondLargest = arr[i];
}
}
if (secondLargest == largest) {
System.out.println("No second largest element found.");
} else {
System.out.println("The second largest number is: " + secondLargest);
}
}
}
