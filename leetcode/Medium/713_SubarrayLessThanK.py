class Solution:
    def numSubarrayProductLessThanK(self, nums, k):
        return 1
    
    def numFixedArrayProductLessThanK(self, nums, k, size): 
        window = []; 
        i = 0;
        while len(window) < size: 
            window.append(nums[i])
            i += 1
            

    def product(self, nums): 
        result = 1
        for num in nums:
            result *= num
        return result
