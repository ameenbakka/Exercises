public class ReverseArray {
    public static void main(String[] args) {
        // Initialize the array
        String[] arr = {"m","a","m"};
String [] arr1={};
        
        // Reverse the array using a for loop
        int start = 0;
        int end = arr.length - 1;
int length = arr.length;
int i;
        // Loop until the start index is less than the end index
        while (start < end) {
            // Swap the elements at start and end positions
            String temp = arr[start];
            arr[start] = arr[end];
            arr[end] = temp;

            // Move the pointers towards the center
            start++;
            end--;
        }
        for (i=0;i<length;i++) {
            arr1[i]=arr[i];
        }
for ( i=0;i<length;i++){
   if(arr1[i]!=arr[i]){
System.out.println("its not palindrome"); }
else{
System.out.println("its palindrome");
}
for(i=0;i<length;i++){
System.out.println(arr[0]);}
for( i=0;i<length;i++){
System.out.println(arr1[0]);}

}
    }
}
