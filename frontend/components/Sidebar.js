import React from 'react';
import Link from 'next/link';

const Sidebar = () => {
  return (
    <div className="bg-gray-800 text-white w-64 min-h-screen p-4">
      <div className="mb-8">
        <div className="text-lg font-bold">Menu</div>
      </div>
      <div className="space-y-4">
        <Link href="/">
          <a className="block hover:text-gray-400">Home</a>
        </Link>
        <Link href="/insights">
          <a className="block hover:text-gray-400">Insights</a>
        </Link>
      </div>
    </div>
  );
};

export default Sidebar;
