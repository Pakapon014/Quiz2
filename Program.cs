using System;

class Program {
    static void Main(string[] args) {
        int N, K, count = 0;
        Console.Write("Enter the number of contestants: ");
        N = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter the maximum number of contestants that each judge can manage: ");
        K = Convert.ToInt32(Console.ReadLine());
        int[] scores = new int[N];
        for (int i = 0; i < N; i++) {
            Console.Write("Enter the score of contestant {0}: ", i + 1);
            scores[i] = Convert.ToInt32(Console.ReadLine());
        }
        int[] assigned = new int[N];
        for (int i = 0; i < N; i++) {
            assigned[i] = -1;
        }
        for (int score = 10; score >= 9; score--) {
            for (int i = 0; i < N; i++) {
                if (scores[i] == score) {
                    for (int j = 0; j < 2; j++) {
                        if (count < N && assigned[i] == -1 && CanManageMore(assigned, K, i)) {
                            assigned[i] = j;
                            count++;
                        }
                    }
                }
            }
        }
        for (int score = 8; score >= 0; score--) {
            for (int i = 0; i < N; i++) {
                if (scores[i] == score) {
                    for (int j = 0; j < 2; j++) {
                        if (count < N && assigned[i] == -1 && CanManageMore(assigned, K, i) && CanBeAssignedWith(j, assigned, scores, i)) {
                            assigned[i] = j;
                            count++;
                        }
                    }
                }
            }
        }
        Console.WriteLine("The following contestants are selected:");
        for (int i = 0; i < N; i++) {
            if (assigned[i] != -1) {
                Console.WriteLine("Contestant {0} (score: {1}) managed by judge {2}", i + 1, scores[i], assigned[i] + 1);
            }
        }
        Console.ReadKey();
    }

    static bool CanManageMore(int[] assigned, int K, int contestant) {
        int count = 0;
        for (int i = 0; i < assigned.Length; i++) {
            if (assigned[i] == contestant) {
                count++;
            }
        }
        return count < K;
    }

    static bool CanBeAssignedWith(int judge, int[] assigned, int[] scores, int contestant) {
        for (int i = 0; i < assigned.Length; i++) {
            if (assigned[i] == judge && scores[i] >= 9 && i != contestant) {
                return false;
            }
        }
        return true;
    }
}