import React from 'react';

interface StatsProps {
  count: number;
  label: string;
}

export function Stats({ count, label }: StatsProps) {
  return (
    <div className="bg-gradient-to-br from-purple-500 to-pink-500 text-white rounded-lg p-8 text-center shadow-lg">
      <div className="text-4xl font-bold mb-2">{count}</div>
      <div className="text-lg opacity-90">{label}</div>
    </div>
  );
}
